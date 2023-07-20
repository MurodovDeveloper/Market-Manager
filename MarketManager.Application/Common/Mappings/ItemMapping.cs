using AutoMapper;
using MarketManager.Application.UseCases.Items.Commands.CreateItem;
using MarketManager.Application.UseCases.Items.Commands.DeleteItem;
using MarketManager.Application.UseCases.Items.Commands.UpdateItem;
using MarketManager.Domain.Entities;

namespace MarketManager.Application.Common.Mappings
{
    public class ItemMapping : Profile
    {
        public ItemMapping()
        {
            CartWithCart();
        }

        private void CartWithCart()
        {
            CreateMap<CreateItemCommand, Item>();
            CreateMap<UpdateItemCommand, Item>();
            CreateMap<DeleteItemCommand, Item>();
        }
    }
}
