﻿using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Clients.Commands.CreateClient;
using MarketManager.Application.UseCases.Clients.Commands.DeleteClient;
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
        [HttpGet("[action]")]
        public async ValueTask<ActionResult<PaginatedList<GetAllClientsQueryResponse>>> GetAllClients(int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetAllClientsQuery { PageNumber = pageNumber, PageSize = pageSize };
            return await _mediator.Send(query);
        }

        [HttpGet("[action]")]
        public async ValueTask<GetClientByIdQueryResponse> GetClientById(Guid Id)
        {
            return await _mediator.Send(new GetClientByIdQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateClient(CreateClientCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteClient(DeleteClientCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

