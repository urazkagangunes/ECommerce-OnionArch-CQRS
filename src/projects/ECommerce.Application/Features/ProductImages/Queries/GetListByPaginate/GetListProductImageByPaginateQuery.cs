using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Extensions;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.ProductImages.Queries.GetListByPaginate;

public sealed class GetListProductImageByPaginateQuery : IRequest<Paginate<GetPaginateProductImageResponse>>
{
    public PageRequest PageRequest { get; set; }
    public string CacheKey => $"GetListProductImage({PageRequest.PageIndex}, {PageRequest.PageSize})";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "ProductImages";
    public TimeSpan? SlidingExpiration { get; }

    public sealed class GetListProductImageByPaginateQueryHandler
        : IRequestHandler<GetListProductImageByPaginateQuery, Paginate<GetPaginateProductImageResponse>>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public GetListProductImageByPaginateQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }
        public async Task<Paginate<GetPaginateProductImageResponse>> Handle(GetListProductImageByPaginateQuery request, CancellationToken cancellationToken)
        {
            var images = await _productImageRepository.GetPaginateAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            var response = _mapper.Map<Paginate<GetPaginateProductImageResponse>>(images);

            return response;
        }
    }
}