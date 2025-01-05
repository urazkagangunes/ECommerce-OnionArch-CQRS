using AutoMapper;
using ECommerce.Application.Services.Infrastructure;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.ProductImages.Commands.Create;

public sealed class ProductImageAddCommand : IRequest<ProductImageAddedResponseDto>
{
    public Guid ProductId { get; set; }
    public IFormFile File { get; set; }

    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "ProductImages";

    public sealed class ProductImageAddCommandHandler : IRequestHandler<ProductImageAddCommand, ProductImageAddedResponseDto>
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductImageAddCommandHandler(ICloudinaryService cloudinaryService, IProductImageRepository productImageRepository, IMapper mapper)
        {
            _cloudinaryService = cloudinaryService;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<ProductImageAddedResponseDto> Handle(ProductImageAddCommand request, CancellationToken cancellationToken)
        {
            var url = await _cloudinaryService.UploadImage(request.File, "E-commerce-product-images");
            var productImage = _mapper.Map<ProductImage>(request);
            productImage.Url = url;

            var created = await _productImageRepository.AddAsync(productImage);
            var response = _mapper.Map<ProductImageAddedResponseDto>(created);
            return response;
        }
    }
}
