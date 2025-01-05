namespace ECommerce.Application.Features.ProductImages.Commands.Create;

public class ProductImageAddedResponseDto
{
    public int Id { get; set; }
    public string Url { get; set; } = default!;
    public Guid ProductId { get; set; }
}