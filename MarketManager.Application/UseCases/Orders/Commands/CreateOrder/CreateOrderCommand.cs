using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Orders.Commands.CreateOrder;


public class CreateOrderCommand : IRequest<Guid>
{
    public decimal TotalPrice { get; set; }

    public Guid ClientId { get; set; }
    public decimal CardPriceSum { get; set; }
    public decimal CashPurchaseSum { get; set; }

    public ICollection<Guid> Items { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public CreateOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {

        IEnumerable<Item>? items = FilterIfAllItemsExsist(request.Items);
        
        Order order= _mapper.Map<Order>(request);
        order.Items = items.ToList();
        await _dbContext.Orders.AddAsync(order, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
         
        return order.Id;
    }

    private IEnumerable<Item> FilterIfAllItemsExsist(ICollection<Guid> items)
    {
        foreach (Guid Id in items)
            yield return _dbContext.Items.Include("Items").FirstOrDefault(c => c.Id == Id)
                ?? throw new NotFoundException($" There is no item with this {Id} id. ");
    }
}
