using ECommerce.Application.Features.Categories.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly IMediator _mediator;
        
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryAddCommand command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }
    }
}
