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
        public string SearchingText { get; } = string.Empty;
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
            var allProducts = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchingText))
            {
                allProducts = allProducts.Where(p => p.Name.Contains(request.SearchingText));
                allProducts = allProducts.Where(p => p.Description.Contains(request.SearchingText));
                allProducts = allProducts.Where(p => p.ProductType.Name.Contains(request.SearchingText));
                //allProducts = allProducts.Where(p => p.Packages.ToList()Contains(request.SearchingText));
            }
            var paginatedProducts = await PaginatedList<Product>.CreateAsync(allProducts, request.PageNumber, request.PageSize);
            var response = _mapper.Map<PaginatedList<Product>, PaginatedList<GetAllProductsQueryResponse>>(paginatedProducts);
            return response;
        }
    }

}
