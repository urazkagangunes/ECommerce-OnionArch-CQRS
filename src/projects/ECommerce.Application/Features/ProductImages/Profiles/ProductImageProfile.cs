using AutoMapper;
using Core.Persistence.Extensions;
using ECommerce.Application.Features.ProductImages.Commands.Create;
using ECommerce.Application.Features.ProductImages.Queries.GetList;
using ECommerce.Application.Features.ProductImages.Queries.GetListByPaginate;
using ECommerce.Application.Features.ProductImages.Queries.GetListByProductId;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.ProductImages.Profiles;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImageAddCommand, ProductImage>();
        CreateMap<ProductImage, ProductImageAddedResponseDto>();
        CreateMap<ProductImage, GetListProductImageResponseDto>();
        CreateMap<ProductImage, GetPaginateProductImageResponse>();
        CreateMap<Paginate<ProductImage>, Paginate<GetPaginateProductImageResponse>>();
        CreateMap<ProductImage, GetListByProductIdResponse>();
    }
}
