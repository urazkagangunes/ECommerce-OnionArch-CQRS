﻿namespace ECommerce.Application.Features.ProductImages.Queries.GetList;

public class GetListProductImageResponseDto
{
    public int Id { get; set; }
    public string Url { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
}
