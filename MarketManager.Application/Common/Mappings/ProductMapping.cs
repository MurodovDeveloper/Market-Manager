using AutoMapper;
using MarketManager.Application.UseCases.Products.Commands.CreateProduct;
using MarketManager.Application.UseCases.Products.Commands.DeleteProduct;
using MarketManager.Application.UseCases.Products.Commands.UpdateProduct;
using MarketManager.Application.UseCases.Products.Queries.GetAllProducts;
using MarketManager.Application.UseCases.Products.Queries.GetByIdProduct;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings;
public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<DeleteProductCommand, Product>().ReverseMap();
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
        CreateMap<Product, GetAllProductsQueryResponse>().ReverseMap();
        CreateMap<Product, GetProductByIdQueryResponse>().ReverseMap();
    }
}
