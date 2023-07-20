using MarketManager.Application.UseCases.Packages.Commands.CreatePackage;
using MarketManager.Application.UseCases.Packages.Commands.UpdatePackage;
using MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;
using MarketManager.Application.UseCases.Packages.Queries.GetPackageById;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : BaseApiController
    {
        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GetAllPackagesQueryResponse>> GetAllPackages()
        {
            return await _mediator.Send(new GetAllPackagesQuery());
        }

        [HttpGet("[action]")]
        public async ValueTask<GetPackageByIdQueryResponse> GetPackageById(Guid Id)
        {
            return await _mediator.Send(new GetPackageByIdQuery(Id));
        }

        [HttpPost("[action]")]
        public async ValueTask<Guid> CreatePackage(CreatePackageCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdatePackage(UpdatePackageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeletePackage(UpdatePackageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
