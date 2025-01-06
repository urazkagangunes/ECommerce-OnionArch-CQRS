namespace ECommerce.Application.Features.Products.Queries.GetList;

public class GetListProductResponseDto
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    public int Stock { get; set; }
    public string CategoryName { get; set; }
}