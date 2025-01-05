using AutoMapper;
using Core.Application.Pipelines.Caching;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.ProductImages.Queries.GetList;

public sealed class GetListPrroductImageQuery : IRequest<List<GetListProductImageResponseDto>>, ICachableRequest
{
    public string CacheKey => "GetListProductImages";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "ProductImages";
    public TimeSpan? SlidingExpiration { get; }

    public sealed class GetListProductImageQueryHandler : IRequestHandler<GetListPrroductImageQuery, List<GetListProductImageResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;

        public GetListProductImageQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListProductImageResponseDto>> Handle(GetListPrroductImageQuery request, CancellationToken cancellationToken)
        {
            var images = await _productImageRepository.GetListAsync(
                cancellationToken: cancellationToken,
                enableTracking: false
                );

            var response = _mapper.Map<List<GetListProductImageResponseDto>>(images);

            return response;
        }
    }
}