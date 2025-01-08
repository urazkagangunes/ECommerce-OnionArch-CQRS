using Core.Persistence.Repositories;
using Core.Security.Entities;
using ECommerce.Application.Services.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}
