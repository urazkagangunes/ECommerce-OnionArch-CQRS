using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class ProductImageRepository : EfRepositoryBase<ProductImage, int, BaseDbContext>, IProductImageRepository
{
    public ProductImageRepository(BaseDbContext context) : base(context)
    {
    }
}
