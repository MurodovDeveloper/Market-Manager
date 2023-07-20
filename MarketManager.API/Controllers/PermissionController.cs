using MarketManager.Application.UseCases.Permissions.Queries.GetAllPermissions;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PermissionController : BaseApiController
{


    [HttpGet("[action]")]
    public async ValueTask<List<PermissionResponse>> GetAllPermissions(GetAllPermissionQuery query)
        => await _mediator.Send(query);
}
