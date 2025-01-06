namespace ECommerce.Application.Features.Products.Commands.Update;

public class ProductUpdateResponseDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    public int Stock { get; set; }
    public int SubCategoryId { get; set; }
}