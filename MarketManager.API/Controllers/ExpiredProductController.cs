using MarketManager.Application.Common.Models;
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
        [HttpGet("[action]")]
        public async ValueTask<PaginatedList<GetAllExpiredProductsResponce>> GelAllExpiredProduct([FromQuery] GetAllExpiredProductsQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("[action]")]
        public async ValueTask<GetByIdExpiredProductsResponce> GetByIdExpiredProduct(Guid Id)
        {
            return await _mediator.Send(new GetByIdExpiredProductsQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateExpiredProduct(CreateExpiredProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateExpiredProduct(UpdateExpiredProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteExpiredProduct(DeleteExpiredProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
