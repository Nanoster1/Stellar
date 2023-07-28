using Stellar.Core.RepositoryPattern.Abstractions;
using Stellar.IS.Domain.Users;
using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Application.Common.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{
}
