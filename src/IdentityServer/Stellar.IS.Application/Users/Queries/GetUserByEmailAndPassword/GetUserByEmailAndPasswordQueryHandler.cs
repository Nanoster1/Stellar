using ErrorOr;

using MediatR;

using Stellar.IS.Application.Common.Repositories;
using Stellar.IS.Application.Common.Services.Interfaces;
using Stellar.IS.Application.Common.Specifications;
using Stellar.IS.Domain.Common.Errors;

using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Application.Users.Queries.ValidateUserPassword;

public class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<ValidateUserPasswordQuery, ErrorOr<bool>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashProvider _passwordHashProvider;
    private readonly IPasswordHashEqualityProvider _passwordHashEqualityProvider;

    public GetUserByEmailAndPasswordQueryHandler(
        IUserRepository userRepository,
        IPasswordHashProvider passwordHashProvider,
        IPasswordHashEqualityProvider passwordHashEqualityProvider)
    {
        _userRepository = userRepository;
        _passwordHashProvider = passwordHashProvider;
        _passwordHashEqualityProvider = passwordHashEqualityProvider;

    }


    public async Task<ErrorOr<bool>> Handle(ValidateUserPasswordQuery request, CancellationToken cancellationToken)
    {
        var userEmailCreateResult = UserEmail.Create(request.Email);
        if (userEmailCreateResult.IsError) return userEmailCreateResult.Errors;
        var userEmail = userEmailCreateResult.Value;

        var emailSpec = UserSpecs.EmailEquals(userEmail);
        var user = await _userRepository.FindOneAsync(emailSpec, cancellationToken);
        if (user == null) return UserErrors.UserWithEmailNotFound(userEmail);

        var password = _passwordHashProvider.Hash(request.Password, user.PasswordInfo.Salt);
        return _passwordHashEqualityProvider.HashesAreEqual(password.Hash, user.PasswordInfo.Hash);
    }
}
