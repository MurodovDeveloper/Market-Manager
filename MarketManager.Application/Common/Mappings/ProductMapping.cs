using AutoMapper;
using MarketManager.Application.UseCases.Products.Commands.CreateProduct;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings;
public class ProductMapping:Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductCommand,Product>().PreserveReferences();
    }
}
