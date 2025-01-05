using AutoMapper;
using Core.Application.Pipelines.Performance;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetList;

public sealed class GetListCategoryQuery : IRequest<List<GetListCategoryResponseDto>>, IPerformanceRequest
{
    public sealed class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<GetListCategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListCategoryResponseDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetListAsync(
                include: false,
                enableTracking: false,
                cancellationToken: cancellationToken
                );

            List<GetListCategoryResponseDto> responseDtos = _mapper.Map<List<GetListCategoryResponseDto>>(categories);

            return responseDtos;
        }
    }
}