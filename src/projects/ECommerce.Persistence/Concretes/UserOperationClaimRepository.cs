using Core.Persistence.Repositories;
using Core.Security.Entities;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}
