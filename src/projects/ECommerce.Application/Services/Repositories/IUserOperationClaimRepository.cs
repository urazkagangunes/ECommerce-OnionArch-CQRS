using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace ECommerce.Persistence.Abstracts;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int> { }