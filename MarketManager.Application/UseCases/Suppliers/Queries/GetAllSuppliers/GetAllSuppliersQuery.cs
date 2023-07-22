using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Suppliers.Queries.GetAllSuppliers;

public record GetAllSuppliersQuery : IRequest<List<GetAllSuppliersQueryResponse>>;
public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, List<GetAllSuppliersQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllSuppliersQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<GetAllSuppliersQueryResponse>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        var suppliers = await _context.Suppliers.ToListAsync(cancellationToken);
        var res = _mapper.Map<List<GetAllSuppliersQueryResponse>>(suppliers);
        return res;
    }
}
public class GetAllSuppliersQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}
