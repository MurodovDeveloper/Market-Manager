using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Products.Queries.GetAllProducts;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Queries.GetAllProductsWithPagination
{
    public record GetAllProductsPaginationQuery : IRequest<PaginatedList<GetAllProductsQueryResponse>>
    {
        public int ListId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
    public class GetAllProductsPaginationQueryHandler : IRequestHandler<GetAllProductsPaginationQuery, PaginatedList<GetAllProductsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllProductsPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaginatedList<GetAllProductsQueryResponse>> Handle(GetAllProductsPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products // Assuming you have a DbSet<Product> in your ApplicationDbContext
                .Select(p => _mapper.Map<Product, GetAllProductsQueryResponse>(p));

            return await PaginatedList<GetAllProductsQueryResponse>.CreateAsync(query, request.PageNumber, request.PageSize);
        }
    }

}
