using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Queries.GetByIdProduct
{
    public record GetProductByIdQuery(Guid Id) : IRequest<GetProductByIdQueryResponse>;

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product? Product = await _context.Products.FindAsync(request.Id);

            if (Product is null)
                throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<GetProductByIdQueryResponse>(Product);
        }
    }
    public class GetProductByIdQueryResponse
    {
        public Guid Id { get; set; }
    }
}
