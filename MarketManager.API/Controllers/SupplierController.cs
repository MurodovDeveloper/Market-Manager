﻿
using MarketManager.Application.UseCases.Suppliers.Commands.CreateSupplier;
using MarketManager.Application.UseCases.Suppliers.Commands.DeleteSupplier;
using MarketManager.Application.UseCases.Suppliers.Commands.UpdateSupplier;
using MarketManager.Application.UseCases.Suppliers.Queries.GetAllSuppliers;
using MarketManager.Application.UseCases.Suppliers.Queries.GetSupplierById;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseApiController
    {
        [HttpGet]
        public async ValueTask<IEnumerable<GetAllSuppliersQueryResponse>> GetAllSuppliers()
        {
            return await _mediator.Send(new GetAllSuppliersQuery());
        }

        [HttpGet]
        public async ValueTask<GetSupplierByIdQueryRespnse> GetSupplierById(Guid Id)
        {
            return await _mediator.Send(new GetSupplierByIdQuery(Id));
        }

        [HttpPost]
        public async ValueTask<Guid> CreateSupplier(CreateSupplierCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateSupplier(UpdateSupplierCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteSupplier(DeleteSupplierCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
