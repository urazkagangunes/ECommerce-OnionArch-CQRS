using AutoMapper;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public sealed class CategoryAddCommand : IRequest<CategoryAddedResponseDto>
{
    public string Name { get; set; } = default!;

    public sealed class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, CategoryAddedResponseDto>
    {
        private readonly IMapper _mapper;
        public CategoryAddCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<CategoryAddedResponseDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
            CategoryAddedResponseDto response = _mapper.Map<CategoryAddedResponseDto>(category);

            return Task.FromResult(response);
        }
    }
}
