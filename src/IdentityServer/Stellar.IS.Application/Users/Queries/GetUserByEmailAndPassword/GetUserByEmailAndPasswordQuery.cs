using ErrorOr;

using MediatR;

namespace Stellar.IS.Application.Users.Queries.ValidateUserPassword;

public record GetUserByEmailAndPasswordQuery(string Email, string Password) : IRequest<ErrorOr<bool>>;
