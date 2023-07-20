using MarketManager.Application.UseCases.Products.Commands.CreateProduct;
using MarketManager.Application.UseCases.Products.Commands.UpdateProduct;
using MarketManager.Application.UseCases.Products.Queries.GetAllProducts;
using MarketManager.Application.UseCases.Products.Queries.GetByIdProduct;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GetAllProductsQueryResponse>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        [HttpGet("[action]")]
        public async ValueTask<GetProductByIdQueryResponse> GetProductById(Guid Id)
        {
            return await _mediator.Send(new GetProductByIdQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreateProduct(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
