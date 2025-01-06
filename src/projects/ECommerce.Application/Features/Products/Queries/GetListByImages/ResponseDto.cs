namespace ECommerce.Application.Features.Products.Queries.GetListByImages;

public class ResponseDto
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    public int Stock { get; set; }
    public string CategoryName { get; set; }
    public List<string> Urls { get; set; }
}