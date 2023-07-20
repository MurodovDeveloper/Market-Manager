﻿using MarketManager.Application.UseCases.Roles.Commands.CreateRole;
using MarketManager.Application.UseCases.Roles.Commands.DeleteRole;
using MarketManager.Application.UseCases.Roles.Commands.UpdateRole;
using MarketManager.Application.UseCases.Roles.Queries;
using MarketManager.Application.UseCases.Roles.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<RoleResponse> GetRoleById(GetByIdRoleQuery query)
        => await _mediator.Send(query);

    [HttpGet("[action]")]
    public async ValueTask<List<RoleResponse>> GetAllRoles(GetAllRoleQuery query)
        => await _mediator.Send(query);

    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateRole(CreateRoleCommand command)
        => await _mediator.Send(command);

    [HttpPut("[action]")]
    public async ValueTask<IActionResult> UpdateRole(UpdateRoleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeleteRole(DeleteRoleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
