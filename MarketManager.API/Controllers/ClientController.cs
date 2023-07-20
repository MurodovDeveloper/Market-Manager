using MarketManager.Application.UseCases.Clients.Commands.CreateClient;
using MarketManager.Application.UseCases.Clients.Commands.UpdateClient;
using MarketManager.Application.UseCases.Clients.Queries.GetAllClients;
using MarketManager.Application.UseCases.Clients.Queries.GetClientById;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<IEnumerable<GetAllClientsQueryResponse>> GetAllClients()
        {
            return await _mediator.Send(new GetAllClientsQuery());
        }

        [HttpGet]
        public async ValueTask<GetClientByIdQueryResponse> GetClientById(Guid Id)
        {
            return await _mediator.Send(new GetClientByIdQuery(Id));
        }

        [HttpPost]
        public async ValueTask<Guid> CreateClient(CreateClientCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteClient(UpdateClientCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

