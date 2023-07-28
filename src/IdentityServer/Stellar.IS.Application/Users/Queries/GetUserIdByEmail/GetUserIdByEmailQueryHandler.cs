using ErrorOr;

using MediatR;

using Stellar.IS.Application.Common.Repositories;
using Stellar.IS.Application.Common.Specifications;
using Stellar.IS.Domain.Common.Errors;
using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Application.Users.Queries.GetUserIdByEmail;

public class GetUserIdByEmailQueryHandler : IRequestHandler<GetUserIdByEmailQuery, ErrorOr<Guid>>
{
    private readonly IUserRepository _userRepository;

    public GetUserIdByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(GetUserIdByEmailQuery request, CancellationToken cancellationToken)
    {
        var userEmailCreateResult = UserEmail.Create(request.Email);
        if (userEmailCreateResult.IsError) return userEmailCreateResult.Errors;

        var userEmail = userEmailCreateResult.Value;

        var emailSpec = UserSpecs.EmailEquals(userEmail);
        var user = await _userRepository.FindOneAsync(emailSpec, cancellationToken);

        return user is null
            ? UserErrors.UserWithEmailNotFound(userEmail)
            : user.Id.Value;
    }
}