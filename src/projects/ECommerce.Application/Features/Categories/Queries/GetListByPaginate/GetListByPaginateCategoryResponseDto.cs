namespace ECommerce.Application.Features.Categories.Queries.GetListByPaginate;

public class GetListByPaginateCategoryResponseDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; } = default!;
}