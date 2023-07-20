using MarketManager.Application.UseCases.Items.Commands.CreateItem;
using MarketManager.Application.UseCases.Items.Commands.UpdateItem;
using MarketManager.Application.UseCases.Items.Queries.GetAllItems;
using MarketManager.Application.UseCases.Items.Queries.GetItemById;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseApiController
    {
        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GetAllItemsQueryResponse>> GetAllItems()
        {
            return await _mediator.Send(new GetAllItemsQuery());
        }

        [HttpGet("[action]")]
        public async ValueTask<GetItemByIdQueryResponse> GetItemById(Guid Id)
        {
            return await _mediator.Send(new GetItemByIdQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateItem(CreateItemCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateItem(UpdateItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteItem(UpdateItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
