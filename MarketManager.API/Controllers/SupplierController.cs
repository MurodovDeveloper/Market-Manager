using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Clients.Queries.GetAllClients;
using MarketManager.Application.UseCases.Permissions.Queries.GetAllPermissions;
using MarketManager.Application.UseCases.Suppliers.Commands.CreateSupplier;
using MarketManager.Application.UseCases.Suppliers.Commands.DeleteSupplier;
using MarketManager.Application.UseCases.Suppliers.Commands.UpdateSupplier;
using MarketManager.Application.UseCases.Suppliers.Queries.GetAllSuppliers;
using MarketManager.Application.UseCases.Suppliers.Queries.GetSupplierById;
using MarketManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseApiController
    {

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<PaginatedList<GetAllSuppliersQueryResponse>>> GetAllSuppliers([FromQuery] GetAllSuppliersQuery query)
        {     
            return await _mediator.Send(query);
        }
            
        [HttpGet("[action]")]
        public async ValueTask<GetSupplierByIdQueryRespоnse> GetSupplierById(Guid Id)
        {
            return await _mediator.Send(new GetSupplierByIdQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateSupplier(CreateSupplierCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateSupplier(UpdateSupplierCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteSupplier(DeleteSupplierCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
