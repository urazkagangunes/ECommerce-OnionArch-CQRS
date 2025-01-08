using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Commands.Delete;
using ECommerce.Application.Features.Products.Commands.Update;
using ECommerce.Application.Features.Products.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : BaseController
{
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll() =>
        Ok(await mediator.Send(new GetListProductQuery()));

    [HttpPost("create")]
    public async Task<IActionResult> Add(ProductAddCommand command) =>
        Ok(await mediator.Send(command));

    [HttpGet("getallbyimages")]
    public async Task<IActionResult> GetAllByImagesUrls() =>
        Ok(await mediator.Send(new Application.Features.Products.Queries.GetListByImages.Query()));

    [HttpGet("elasticall")]
    public async Task<IActionResult> GetAllElastic() =>
        Ok(await mediator.Send(new Application.Features.Products.Queries.GetListByElasticSearch.Query()));

    [HttpGet("filter")]
    public async Task<IActionResult> GetAllByFilter([FromQuery] string text)
    {
        var query = new Application.Features.Products.Queries.GetListFilterByElasticSearch.Query { Text = text };
        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var query = new ProductDeleteCommand() { Id = id };
        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] ProductUpdateCommand command) =>
        Ok(await mediator.Send(command));

}