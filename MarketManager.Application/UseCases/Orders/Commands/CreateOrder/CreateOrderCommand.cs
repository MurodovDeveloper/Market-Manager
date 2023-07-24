using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Orders.Commands.CreateOrder;


public class CreateOrderCommand : IRequest<Guid>
{
    public decimal TotalPrice { get; set; }
    public decimal ItemPriceSum { get; set; }
    public Guid ClientId { get; set; }
    public decimal ItemPurchaseSum { get; set; }

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


            Order order = _mapper.Map<Order>(request);
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
 }

