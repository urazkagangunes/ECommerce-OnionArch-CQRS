using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.ElasticSearch.Services.Abstrascts;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Create;

public class ProductAddCommand : IRequest<ProductAddResponseDto>, ILoggableRequest, ICacheRemoverRequest, ITransactionalRequest
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    public int Stock { get; set; }
    public int SubCategoryId { get; set; }

    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "Products";

    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, ProductAddResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IElasticSearchClientService _elasticSearchClientService;

        public ProductAddCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules, IElasticSearchClientService elasticSearchClientService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _elasticSearchClientService = elasticSearchClientService;
        }

        public async Task<ProductAddResponseDto> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            product.Id = Guid.NewGuid();

            var created = await _productRepository.AddAsync(product);

            var response = _mapper.Map<ProductAddResponseDto>(created);

            await _elasticSearchClientService.IndexDocumentAsync(response, "products");

            return response;
        }
    }
}