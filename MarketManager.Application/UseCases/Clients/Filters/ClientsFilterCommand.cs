using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Clients.Filters;
public class ClientsFilterCommand : IRequest<List<Client>>
{
    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool OrderByDiscount { get; set; } = false;

    public bool OrderByTotalPrice { get; set; } = false;

}
public class ClientsFilterCommandHandler : IRequestHandler<ClientsFilterCommand, List<Client>>
{
    private readonly IApplicationDbContext _context;

    public ClientsFilterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> Handle(ClientsFilterCommand request, CancellationToken cancellationToken)
    {
        if (request.StartDate is null)
            request.StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));


        if (request.EndDate is null)
            request.EndDate = DateOnly.FromDateTime(DateTime.Now);


        if (request.OrderByDiscount && !request.OrderByTotalPrice)
        {
            return await _context.Clients
                .Where(date=> DateOnly.FromDateTime(date.CreatedDate) >= request.StartDate && DateOnly.FromDateTime(date.CreatedDate)<= request.EndDate)
                .OrderByDescending(x => x.Discount).ToListAsync(cancellationToken);

        }
        if (request.OrderByTotalPrice && !request.OrderByDiscount)
        {
            return await _context.Clients
                 .Where(date => DateOnly.FromDateTime(date.CreatedDate) >= request.StartDate && DateOnly.FromDateTime(date.CreatedDate) <= request.EndDate)
                .OrderByDescending(x => x.TotalPrice).ToListAsync(cancellationToken);
        }
        else
        {
            return await _context.Clients
                .Where(date => DateOnly.FromDateTime(date.CreatedDate) >= request.StartDate && DateOnly.FromDateTime(date.CreatedDate) <= request.EndDate)
                .OrderByDescending(x => x.TotalPrice).ThenByDescending(x => x.Discount).ToListAsync(cancellationToken);
        }

    }
}
