using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
namespace MarketManager.Application.UseCases.Clients.Queries.GetAllClients;

public record GetAllClientsQuery : IRequest<IEnumerable<GetAllClientsQueryResponse>>;
public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<GetAllClientsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllClientsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<IEnumerable<GetAllClientsQueryResponse>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Client> clients = _context.Clients;
        return Task.FromResult(_mapper.Map<IEnumerable<GetAllClientsQueryResponse>>(clients));
    }
}
public class GetAllClientsQueryResponse
{
    public Guid Id { get; set; }
    public double TotalPrice { get; set; }
    public double Discount { get; set; }
}
