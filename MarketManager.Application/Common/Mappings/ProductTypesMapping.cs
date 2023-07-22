using AutoMapper;
using MarketManager.Application.UseCases.Clients.Queries.GetAllClients;
using MarketManager.Application.UseCases.ExpiredProducts.Queries;
using MarketManager.Application.UseCases.Products.Commands.DeleteProduct;
using MarketManager.Application.UseCases.Products.Commands.UpdateProduct;
using MarketManager.Application.UseCases.ProductTypes.Commands.CreateProductsType;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings;

public class ProductTypesMapping : Profile
{
    public ProductTypesMapping()
    {
        CreateMap<CreateProductTypeCommand, ProductType>().ReverseMap();
        CreateMap<UpdateProductCommand, ProductType>().ReverseMap();
        CreateMap<DeleteProductCommand, ProductType>().ReverseMap();
        CreateMap<GetAllClientsQueryResponse, ProductType>().ReverseMap();
        CreateMap<GetByIdExpiredProductsResponce, ProductType>().ReverseMap();
    }
}
