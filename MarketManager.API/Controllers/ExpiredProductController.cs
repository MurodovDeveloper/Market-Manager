using MarketManager.Application.UseCases.ExpiredProducts.Command.CreateExpiredProduct;
using MarketManager.Application.UseCases.ExpiredProducts.Command.DeleteExpiredProduct;
using MarketManager.Application.UseCases.ExpiredProducts.Command.UpdateExpiredProduct;
using MarketManager.Application.UseCases.ExpiredProducts.Queries;
using MarketManager.Application.UseCases.ExpiredProducts.Queries.GetAllExpiredProducts;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpiredProductController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<IEnumerable<GetAllExpiredProductsResponce>> GelAllExpiredProduct()
        {
            return await _mediator.Send(new GetAllExpiredProductsQuery());
        }

        [HttpGet]
        public async ValueTask<GetByIdExpiredProductsResponce> GetByIdExpiredProduct()
        {
            return await _mediator.Send(new GetByIdExpiredProductsQuery());
        }

        [HttpPost]
        public async ValueTask<Guid> CreateExpiredProduct()
        {
            return await _mediator.Send(new CreateExpiredProductCommand());
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateExpiredProduct()
        {
             await _mediator.Send(new UpdateExpiredProductCommand());
            return NoContent();
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteExpiredProduct()
        {
            await _mediator.Send(new DeleteExpiredProductCommand());
            return NoContent();
        }
    }
}
