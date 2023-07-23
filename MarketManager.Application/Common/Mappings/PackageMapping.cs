using AutoMapper;
using MarketManager.Application.UseCases.Packages.Commands.CreatePackage;
using MarketManager.Application.UseCases.Packages.Commands.DeletePackage;
using MarketManager.Application.UseCases.Packages.Commands.UpdatePackage;
using MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;
using MarketManager.Application.UseCases.Packages.Queries.GetPackageById;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings
{
    public class PackageMapping:Profile
    {
        public PackageMapping()
        {
            CreateMap<CreatePackageCommand, Package>();
            CreateMap<DeletePackageCommand, Package>();
            CreateMap<UpdatePackageCommand, Package>();

            CreateMap<Package, GetAllPackagesQueryResponse>();
            CreateMap<Package, GetPackageByIdQuery>();
        }
    }
}
