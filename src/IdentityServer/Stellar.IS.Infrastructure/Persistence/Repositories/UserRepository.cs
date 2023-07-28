using Microsoft.EntityFrameworkCore;

using Stellar.Core.RepositoryPattern.EntityFrameworkCore;
using Stellar.IS.Application.Common.Repositories;
using Stellar.IS.Domain.Users;
using Stellar.IS.Domain.Users.ValueObjects;

namespace Stellar.IS.Infrastructure.Persistence.Repositories;

public class UserRepository : EntityFrameworkRepository<User, UserId>, IUserRepository
{
    public UserRepository(StellarDbContext context) : base(context)
    {
    }
}