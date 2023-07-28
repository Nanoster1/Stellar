using ErrorOr;

using MediatR;

namespace Stellar.IS.Application.Users.Queries.GetUserIdByEmail;

public record GetUserIdByEmailQuery(string Email) : IRequest<ErrorOr<Guid>>;