using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Products.Queries.GetByIdProduct
{
    public record GetProductByIdQuery(Guid Id) : IRequest<GetProductByIdQueryResponse>;

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetProductByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var Product = FilterIfProductExsists(request.Id);

            var result = _mapper.Map<GetProductByIdQueryResponse>(Product);
            return result;
        }

        private Product FilterIfProductExsists(Guid id)
            => _dbContext.Products
                .Find(id)
                     ?? throw new NotFoundException(
                            " There is no Product with this Id. ");


    }

    public class GetProductByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductTypeId { get; set; }
    }
}
