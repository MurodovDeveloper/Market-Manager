using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities.Identity;
using MediatR;

namespace MarketManager.Application.UseCases.Roles.Queries;
public class GetByIdRoleQuery : IRequest<GetRoleByIdQueryResponse>
{
    public Guid Id { get; set; }
}

public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, GetRoleByIdQueryResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetByIdRoleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetRoleByIdQueryResponse> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Roles.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity is null)
            throw new NotFoundException(nameof(Role), request.Id);

        var result = _mapper.Map<GetRoleByIdQueryResponse>(entity);
        return result;
    }
}

public class GetRoleByIdQueryResponse
{
    public Guid Id { get; set; }
}
