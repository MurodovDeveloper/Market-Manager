using AutoMapper;
using MarketManager.Application.UseCases.ExpiredProducts.Command.CreateExpiredProduct;
using MarketManager.Application.UseCases.ExpiredProducts.Command.DeleteExpiredProduct;
using MarketManager.Application.UseCases.ExpiredProducts.Command.UpdateExpiredProduct;
using MarketManager.Application.UseCases.ExpiredProducts.Queries;
using MarketManager.Application.UseCases.ExpiredProducts.Queries.GetAllExpiredProducts;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings.ExpiredProductMappings;

public class ExpiredProductsMappingProfile : Profile
{
	public ExpiredProductsMappingProfile()
	{
        CreateMap<CreateExpiredProductCommand, ExpiredProduct>().ReverseMap();
        CreateMap<UpdateExpiredProductCommand, ExpiredProduct>().ReverseMap();
        CreateMap<DeleteExpiredProductCommand, ExpiredProduct>().ReverseMap();
        CreateMap<GetAllExpiredProductsResponce, ExpiredProduct>().ReverseMap();  
        CreateMap<GetByIdExpiredProductsResponce, ExpiredProduct>().ReverseMap();  

    }
}
