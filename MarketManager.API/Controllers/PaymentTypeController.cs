using MarketManager.Application.UseCases.PaymentTypes.Commands.CreatePaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Commands.DeletePaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Commands.UpdatePaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Queries.GetAllPaymentType;
using MarketManager.Application.UseCases.PaymentTypes.Queries.GetByIdPaymentType;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{

    public class PaymentTypeController : BaseApiController
    {
        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GetAllPaymentTypeQueryResponse>> GetAllPaymentTypes()
        {
            return await _mediator.Send(new GetAllPaymentTypeQuery());
        }

        [HttpGet("[action]")]
        public async ValueTask<GetByIdPaymentTypeQueryResponse> GetPaymentTypeById(Guid id)
        {
            return await _mediator.Send(new GetByIdPaymentTypeQuery() { Id = id });
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreatePaymentType(CreatePaymentTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdatePaymentType(UpdatePaymentTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeletePaymentType(DeletePaymentTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
