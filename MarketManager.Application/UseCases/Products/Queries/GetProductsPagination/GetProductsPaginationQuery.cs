using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.Products.Queries.GetAllProductsWithPagination
{
    public record GetProductsPaginationQuery : IRequest<PaginatedList<GetProductsPaginationQueryResponse>>
    {
        public string? SearchTerm { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
    public class GetProductsPaginationQueryHandler : IRequestHandler<GetProductsPaginationQuery, 
        PaginatedList<GetProductsPaginationQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetProductsPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaginatedList<GetProductsPaginationQueryResponse>> Handle(
            GetProductsPaginationQuery request, CancellationToken cancellationToken)
        {
            var search = request.SearchTerm?.Trim();
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(s => s.Name.ToLower().Contains(search.ToLower()) 
                                            || s.Description.ToLower().Contains(search.ToLower()));
            }
            if (products is null || products.Count() <= 0)
            {
                throw new NotFoundException(nameof(Product), search);
            }

            var paginatedProducts = await PaginatedList<Product>.CreateAsync(
                products, request.PageNumber, request.PageSize);

            var response = _mapper.Map<List<GetProductsPaginationQueryResponse>>(paginatedProducts.Items);

            var result = new PaginatedList<GetProductsPaginationQueryResponse>
                (response, paginatedProducts.TotalCount, paginatedProducts.PageNumber, paginatedProducts.TotalPages);

            return result;
        }
    }

    public class GetProductsPaginationQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }
    }
}
