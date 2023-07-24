using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery : IRequest<IEnumerable<GetAllProductsQueryResponse>>;

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllProductsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<GetAllProductsQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> Products = _context.Products;

            return Task.FromResult(_mapper.Map<IEnumerable<GetAllProductsQueryResponse>>(Products));

        }
    }
    public class GetAllProductsQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }
    }
}
