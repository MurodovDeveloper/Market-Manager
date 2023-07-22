using AutoMapper;
using MarketManager.Application.UseCases.Packages.Commands.CreatePackage;
using MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;
using MarketManager.Application.UseCases.Packages.Queries.GetPackageById;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings
{
    public class PackegeMapping : Profile
    {
        public PackegeMapping()
        {
            CreateMap<CreatePackageCommand, Package>().ReverseMap();
            CreateMap<GetPackageByIdQueryResponse, Package>().ReverseMap();
            CreateMap<GetAllPackagesQueryResponse, Package>().ReverseMap();
        }
    }
}
