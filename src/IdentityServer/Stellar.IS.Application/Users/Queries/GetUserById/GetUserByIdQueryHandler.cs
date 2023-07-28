using ErrorOr;

using MediatR;

using Stellar.IS.Application.Common.Repositories;
using Stellar.IS.Application.Users.Models;
using Stellar.IS.Domain.Common.Errors;
using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userIdCreateResult = UserId.Create(request.UserId);

        if (userIdCreateResult.IsError) return userIdCreateResult.Errors;
        var userId = userIdCreateResult.Value;

        var user = await _userRepository.FindOneAsync(userId, cancellationToken);

        return user is null
            ? UserErrors.UserWithIdNotFound(userId)
            : UserModel.CreateFromDomainUser(user);
    }
}