﻿using MarketManager.Application.UseCases.Permissions.Commands.CreatePermission;
using MarketManager.Application.UseCases.Permissions.Commands.DeletePermission;
using MarketManager.Application.UseCases.Permissions.Commands.UpdatePermission;
using MarketManager.Application.UseCases.Permissions.Queries.GetAllPermissions;
using MarketManager.Application.UseCases.Permissions.Queries.GetPermission;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PermissionController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<PermissionResponse> GetPermissionById(Guid Id)
        => await _mediator.Send(new GetByIdPermissionQuery(Id));

    [HttpGet("[action]")]
    public async ValueTask<List<PermissionResponse>> GetAllPermissions()
        => await _mediator.Send(new GetAllPermissionQuery());

    [HttpPost("[action]")]
    public async ValueTask<List<PermissionResponse>> CreatePermission(CreatePermissionCommand command)
        => await _mediator.Send(command);

    [HttpPut("[action]")]
    public async ValueTask<IActionResult> UpdatePermission(UpdatePermissionCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeletePermission(DeletePermissionCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
