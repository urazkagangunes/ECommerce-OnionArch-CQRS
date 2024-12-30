using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class ProductRepository : EfRepositoryBase<Product, Guid, BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {
    }
}
