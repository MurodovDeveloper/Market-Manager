using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetPackagesPagination
{
    public class GetPackagesPaginationQuery:IRequest<PaginatedList<GetPackagesPaginationQueryResponse>>
    {
        public string? SearchTerm { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetPackagesPaginationQueryHandler : IRequestHandler<GetPackagesPaginationQuery, PaginatedList<GetPackagesPaginationQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetPackagesPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaginatedList<GetPackagesPaginationQueryResponse>> Handle(
            GetPackagesPaginationQuery request, CancellationToken cancellationToken)
        {
            var search = request.SearchTerm.Trim();
            var packages = _context.Packages.AsQueryable();
            
            if (!string.IsNullOrEmpty(search))
            {
                packages = packages.Where(s => s.IncomingCount.ToString().Contains(search) 
                                            || s.ExistCount.ToString().Contains(search) 
                                            || s.IncomingPrice.ToString().Contains(search)
                                            || s.SalePrice.ToString().Contains(search)
                                            || s.IncomingDate.ToString().Contains(search));
            }

            if(packages is null || packages.Count() <= 0)
            {
                throw new NotFoundException(nameof(Package), search);
            }

            var paginatedPackages = await PaginatedList<Package>.CreateAsync(
                packages, request.PageNumber, request.PageSize);

            var response=_mapper.Map<List<GetPackagesPaginationQueryResponse>>(paginatedPackages.Items);

            var result = new PaginatedList<GetPackagesPaginationQueryResponse>
               (response, paginatedPackages.TotalCount, paginatedPackages.PageNumber, paginatedPackages.TotalPages);

            return result;
        }
    }

    public class GetPackagesPaginationQueryResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double IncomingCount { get; set; }
        public double Count { get; set; }
        public Guid SupplierId { get; set; }
        public double IncomingPrice { get; set; }
        public double SalePrice { get; set; }
        public DateTime IncomingDate { get; set; }
    }
}
