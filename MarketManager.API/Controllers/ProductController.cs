using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Products.Commands.CreateProduct;
using MarketManager.Application.UseCases.Products.Commands.UpdateProduct;
using MarketManager.Application.UseCases.Products.Queries.GetAllProducts;
using MarketManager.Application.UseCases.Products.Queries.GetAllProductsWithPagination;
using MarketManager.Application.UseCases.Products.Queries.GetByIdProduct;
using MarketManager.Application.UseCases.Products.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : BaseApiController
{
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateProduct(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async ValueTask<ProductResponse> GetProductById(Guid Id)
    {
        return await _mediator.Send(new GetProductByIdQuery(Id));
    }

    [HttpGet("[action]")]
    public async ValueTask<IEnumerable<ProductResponse>> GetAllProducts()
    {
        return await _mediator.Send(new GetAllProductsQuery());
    }

    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<ProductResponse>>> GetAllProductsPagination(
        [FromQuery] GetProductsPaginationQuery query)
    {
        return await _mediator.Send(query);
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
