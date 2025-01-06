using AutoMapper;
using Core.Application.Pipelines.Caching;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetListByImages;

public class Query : IRequest<List<ResponseDto>>, ICachableRequest
{
    public string CacheKey => "GetAllProductListByImages";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "Products";
    public TimeSpan? SlidingExpiration { get; }

    public class QueryHandler : IRequestHandler<Query, List<ResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public QueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListAsync(
                enableTracking: false,
                cancellationToken: cancellationToken
                );

            var response = _mapper.Map<List<ResponseDto>>(products);
            return response;
        }
    }
}