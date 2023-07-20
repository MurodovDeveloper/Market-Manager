using MarketManager.Application.UseCases.Carts.Commands.CreateCart;
using MarketManager.Application.UseCases.Carts.Commands.UpdateCart;
using MarketManager.Application.UseCases.Carts.Queries.GetAllCarts;
using MarketManager.Application.UseCases.Carts.Queries.GetCartById;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<IEnumerable<GetAllCartsQueryResponse>> GetAllCarts()
        {
            return await _mediator.Send(new GetAllCartsQuery());
        }

        [HttpGet]
        public async ValueTask<GetCartByIdQueryResponse> GetCartById(Guid Id)
        {
            return await _mediator.Send(new GetCartByIdQuery(Id));
        }

        [HttpPost]
        public async ValueTask<Guid> CreateCart(CreateCartCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCart(UpdateCartCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteCart(UpdateCartCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
