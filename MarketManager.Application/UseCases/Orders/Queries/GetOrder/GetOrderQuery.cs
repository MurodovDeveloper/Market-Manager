using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Items.Queries.GetItemById;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.Application.UseCases.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid Id) : IRequest<OrderResponse>;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderResponse>
{
    IApplicationDbContext _dbContext;
    IMapper _mapper;

    public GetOrderQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        Order order = FilterIfOrderExsists(request.Id);

        return _mapper.Map<OrderResponse>(order);
    }

    private Order FilterIfOrderExsists(Guid id)
        => _dbContext.Orders
            .Include(x => x.Items)
            .FirstOrDefault(x => x.Id == id)
                 ?? throw new NotFoundException(
                        " There is no order with this Id. ");


}

