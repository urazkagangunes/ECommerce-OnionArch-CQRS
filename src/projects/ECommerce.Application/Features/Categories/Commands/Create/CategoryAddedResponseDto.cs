namespace ECommerce.Application.Features.Categories.Commands.Create;

public class CategoryAddedResponseDto
{
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; } = default!;
}
