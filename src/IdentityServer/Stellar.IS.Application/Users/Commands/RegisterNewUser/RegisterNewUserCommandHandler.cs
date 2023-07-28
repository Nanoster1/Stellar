using ErrorOr;

using MediatR;

using Stellar.Core.RepositoryPattern.Abstractions;
using Stellar.IS.Application.Common.Repositories;
using Stellar.IS.Application.Common.Services.Interfaces;
using Stellar.IS.Application.Common.Specifications;
using Stellar.IS.Application.Users.Models;
using Stellar.IS.Domain.Common.Errors;
using Stellar.IS.Domain.Users;
using Stellar.IS.Domain.Users.Enums;
using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Application.Users.Commands.RegisterNewUser;

public class RegisterNewUserCommandHandler : IRequestHandler<RegisterNewUserCommand, ErrorOr<UserModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHashProvider _passwordHashProvider;

    public RegisterNewUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHashProvider passwordHashProvider)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHashProvider = passwordHashProvider;
    }

    public async Task<ErrorOr<UserModel>> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        var usernameCreateResult = Username.Create(request.Username);
        if (usernameCreateResult.IsError) errors.AddRange(usernameCreateResult.Errors);

        var userEmailCreateResult = UserEmail.Create(request.Email);
        if (userEmailCreateResult.IsError) errors.AddRange(userEmailCreateResult.Errors);

        var hashedPassword = _passwordHashProvider.Hash(request.Password);
        var userPasswordInfoCreateResult = UserPasswordInfo.Create(hashedPassword.Hash, hashedPassword.Salt);
        if (userPasswordInfoCreateResult.IsError) errors.AddRange(userPasswordInfoCreateResult.Errors);

        if (errors.Count > 0) return errors;

        var username = usernameCreateResult.Value;
        var userEmail = userEmailCreateResult.Value;
        var userPasswordInfo = userPasswordInfoCreateResult.Value;

        var emailSpec = UserSpecs.EmailEquals(userEmail);
        if (await _userRepository.ExistsAsync(emailSpec, cancellationToken))
        {
            return UserErrors.UserWithSameEmailAlreadyExists;
        }

        var userCreateResult = User.Create(
            username,
            userEmail,
            userPasswordInfo,
            UserActivityStatus.Active);

        if (userCreateResult.IsError)
            return userCreateResult.Errors;

        var user = userCreateResult.Value;

        await _userRepository.InsertAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UserModel.CreateFromDomainUser(user);
    }
}