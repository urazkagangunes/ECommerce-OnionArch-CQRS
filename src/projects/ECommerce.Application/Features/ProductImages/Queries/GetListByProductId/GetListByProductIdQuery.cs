using AutoMapper;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.ProductImages.Queries.GetListByProductId;

public sealed class GetListByProductIdQuery : IRequest<List<GetListByProductIdResponse>>
{
    public Guid ProductId { get; set; }

    public sealed class GetListByProductIdQueryHandler : IRequestHandler<GetListByProductIdQuery, List<GetListByProductIdResponse>>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public GetListByProductIdQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListByProductIdResponse>> Handle(GetListByProductIdQuery request, CancellationToken cancellationToken)
        {
            var images = await _productImageRepository.GetListAsync(
                predicate: x => x.ProductId == request.ProductId,
                enableTracking: false,
                cancellationToken: cancellationToken
                );

            var response = _mapper.Map<List<GetListByProductIdResponse>>(images);
            return response;
        }
    }
}
