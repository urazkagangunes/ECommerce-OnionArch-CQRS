using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class UserRepository : EfRepositoryBase<AppUser, int, BaseDbContext>, IAppUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}