using MarketManager.Application.UseCases.Orders.Commands.CreateOrder;
using MarketManager.Application.UseCases.Orders.Commands.DeleteOrder;
using MarketManager.Application.UseCases.Orders.Commands.UpdateOrder;
using MarketManager.Application.UseCases.Orders.Import.Export;
using MarketManager.Application.UseCases.Orders.Queries.GetAllOrders;
using MarketManager.Application.UseCases.Orders.Queries.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.API.Controllers
{
    public class OrderController : BaseApiController
    {
        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<OrderResponse>> GetAllOrders(int page =1)
        {
            IPagedList<OrderResponse> query = (await _mediator
               .Send(new GetAllOrderQuery()))
               .ToPagedList(page, 10);
            return query;
        }

        [HttpGet("[action]")]
        public async ValueTask<OrderResponse> GetOrderById(Guid Id)
        {
            return await _mediator.Send(new GetOrderQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateOrder(CreateOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteOrder(DeleteOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


    }
}