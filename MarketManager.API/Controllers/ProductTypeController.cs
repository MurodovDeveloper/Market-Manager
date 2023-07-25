using MarketManager.Application.UseCases.ProductsType.Commands.DeleteProductType;
using MarketManager.Application.UseCases.ProductsType.Commands.UpdateProductType;
using MarketManager.Application.UseCases.ProductTypes.Commands.CreateProductsType;
using MarketManager.Application.UseCases.ProductTypes.Queries.GetAllProductTypes;
using MarketManager.Application.UseCases.ProductTypes.Queries.GetByIdProductTypeQuery;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : BaseApiController
    {
        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GetAllProductTypesQueryResponse>> GetAllProductTypes()
        {
            return await _mediator.Send(new GetAllProductTypesQuery());
        }

        [HttpGet("[action]")]
        public async ValueTask<GetByIdProductTypeQueryResponce> GetProductTypeById(Guid id)
        {
            return await _mediator.Send(new GetByIdProductTypeQuery(id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateProductType(CreateProductTypeCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateProductType(UpdateProductTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteProductType(DeleteProductTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
