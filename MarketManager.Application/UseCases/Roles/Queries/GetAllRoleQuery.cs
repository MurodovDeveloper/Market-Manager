using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Roles.Queries;
public record GetAllRoleQuery : IRequest<List<GetAllRolesQueryResponse>>
{
}

public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<GetAllRolesQueryResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetAllRolesQueryResponse>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Roles.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<GetAllRolesQueryResponse>>(entities);
        return result;
    }
}

public class GetAllRolesQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
