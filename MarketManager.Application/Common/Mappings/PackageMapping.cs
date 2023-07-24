using AutoMapper;
using MarketManager.Application.UseCases.Packages.Commands.CreatePackage;
using MarketManager.Application.UseCases.Packages.Commands.DeletePackage;
using MarketManager.Application.UseCases.Packages.Commands.UpdatePackage;
using MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;
using MarketManager.Application.UseCases.Packages.Queries.GetPackageById;
using MarketManager.Application.UseCases.Packages.Queries.GetPackagesPagination;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings
{
    public class PackageMapping:Profile
    {
        public PackageMapping()
        {
            CreateMap<CreatePackageCommand, Package>().ReverseMap(); 
            CreateMap<DeletePackageCommand, Package>().ReverseMap(); 
            CreateMap<UpdatePackageCommand, Package>().ReverseMap(); 
            CreateMap<Package, GetAllPackagesQueryResponse>().ReverseMap();
            CreateMap<Package, GetPackageByIdQueryResponse>().ReverseMap();
            CreateMap<Package, GetPackagesPaginationQueryResponse>().ReverseMap();
        }
    }
}
