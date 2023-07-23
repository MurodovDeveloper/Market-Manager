using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Clients.Queries.GetAllClients;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Suppliers.Queries.GetAllSuppliers;

public record GetAllSuppliersQuery : IRequest<PaginatedList<GetAllSuppliersQueryResponse>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, PaginatedList<GetAllSuppliersQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllSuppliersQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<GetAllSuppliersQueryResponse>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Suppliers
            .Select(s => _mapper.Map<Supplier, GetAllSuppliersQueryResponse>(s)) ;
        return await PaginatedList<GetAllSuppliersQueryResponse>.CreateAsync(query, request.PageNumber, request.PageSize);
        
    }
}
public class GetAllSuppliersQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}
