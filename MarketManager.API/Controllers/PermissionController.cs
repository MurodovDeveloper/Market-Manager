using System.Data;
using ClosedXML.Excel;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Permissions.Commands.CreatePermission;
using MarketManager.Application.UseCases.Permissions.Commands.DeletePermission;
using MarketManager.Application.UseCases.Permissions.Commands.UpdatePermission;
using MarketManager.Application.UseCases.Permissions.Queries.GetAllPermissions;
using MarketManager.Application.UseCases.Permissions.Queries.GetPermission;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PermissionController : BaseApiController
{
    private readonly IApplicationDbContext _context;

    public PermissionController(IApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("[action]")]
    public async ValueTask<PermissionResponse> GetPermissionById(Guid Id)
        => await _mediator.Send(new GetByIdPermissionQuery(Id));

    [HttpGet("[action]")]
    public async ValueTask<PaginatedList<PermissionResponse>> GetAllPermissions([FromQuery] GetAllPermissionQuery query)
        => await _mediator.Send(query);

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

    [HttpGet("[action]")]
    public async Task<IActionResult> ExportToExcel()
    {
        var permission = await _context.Permissions.ToListAsync();
        var fileName = "permission.xlsx";
        return GenerateExcel(fileName, permission);
    }

    private FileResult GenerateExcel(string fileName, IEnumerable<Permission> permission)
    {
        DataTable dataTable = new("Permission");
        dataTable.Columns.AddRange(new DataColumn[]
        {
            new DataColumn("Id"),
            new DataColumn("Name")
        });
        foreach (var item in permission)
        {
            dataTable.Rows.Add(item.Id, item.Name);
        }

        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dataTable);
            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                return File(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileName);
            }
        }

    }
}
