namespace ECommerce.Application.Features.Products.Queries.GetListFilterByElasticSearch;

public class ResponseDto
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    public int Stock { get; set; }
    public int SubCategoryId { get; set; }
}