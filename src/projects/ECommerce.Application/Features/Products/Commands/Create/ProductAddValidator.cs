using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.Create;

public class ProductAddValidator : AbstractValidator<ProductAddCommand>
{
    public ProductAddValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters");
    }
}
