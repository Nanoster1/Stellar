using ErrorOr;

using MediatR;

using Stellar.IS.Application.Users.Models;

namespace Stellar.IS.Application.Users.Commands.RegisterNewUser;

public record RegisterNewUserCommand(string Username, string Email, string Password) : IRequest<ErrorOr<UserModel>>;