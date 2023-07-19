using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Suppliers.Queries.GetAllSuppliers;

public record GetAllSuppliersQuery : IRequest<IEnumerable<GetAllSuppliersQueryResponse>>;
public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, IEnumerable<GetAllSuppliersQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllSuppliersQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<IEnumerable<GetAllSuppliersQueryResponse>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Supplier> suppliers = _context.Suppliers;

        return Task.FromResult(_mapper.Map<IEnumerable<GetAllSuppliersQueryResponse>>(suppliers));

    }
}
public class GetAllSuppliersQueryResponse
{
    public string Name { get; set; }
    public string Phone { get; set; }
}
