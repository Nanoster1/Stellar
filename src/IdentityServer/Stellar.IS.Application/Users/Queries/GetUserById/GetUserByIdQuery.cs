using ErrorOr;

using MediatR;

using Stellar.IS.Application.Users.Models;

namespace Stellar.IS.Application.Users.Queries.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IRequest<ErrorOr<UserModel>>;