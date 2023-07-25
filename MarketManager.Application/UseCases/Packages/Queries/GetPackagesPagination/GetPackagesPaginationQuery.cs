using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Packages.Response;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetPackagesPagination
{
    public class GetPackagesPaginationQuery : IRequest<PaginatedList<PackageResponse>>
    {
        public string? SearchTerm { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetPackagesPaginationQueryHandler : IRequestHandler<GetPackagesPaginationQuery, PaginatedList<PackageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetPackagesPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaginatedList<PackageResponse>> Handle(
            GetPackagesPaginationQuery request, CancellationToken cancellationToken)
        {
            var search = request.SearchTerm?.Trim();
            var packages = _context.Packages.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                packages = packages.Where(s => s.IncomingCount.ToString().Contains(search)
                                            || s.ExistCount.ToString().Contains(search)
                                            || s.IncomingPrice.ToString().Contains(search)
                                            || s.SalePrice.ToString().Contains(search)
                                            || s.IncomingDate.ToString().Contains(search));
            }

            if (packages is null || packages.Count() <= 0)
            {
                throw new NotFoundException(nameof(Package), search);
            }

            var paginatedPackages = await PaginatedList<Package>.CreateAsync(
                packages, request.PageNumber, request.PageSize);

            var response = _mapper.Map<List<PackageResponse>>(paginatedPackages.Items);

            var result = new PaginatedList<PackageResponse>
               (response, paginatedPackages.TotalCount, paginatedPackages.PageNumber, paginatedPackages.TotalPages);

            return result;
        }
    }
}
