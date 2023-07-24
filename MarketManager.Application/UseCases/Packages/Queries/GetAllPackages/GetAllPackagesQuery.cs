using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Packages.Response;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetAllPackages;

public record GetAllPackagesQuery : IRequest<IEnumerable<PackageResponse>>;

public class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQuery, IEnumerable<PackageResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllPackagesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<IEnumerable<PackageResponse>> Handle(GetAllPackagesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Package> packages = _context.Packages;

        return Task.FromResult(_mapper.Map<IEnumerable<PackageResponse>>(packages));

    }
}
