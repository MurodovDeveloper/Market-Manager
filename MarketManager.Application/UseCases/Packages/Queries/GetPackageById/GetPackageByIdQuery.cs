using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetPackageById
{
    public record GetPackageByIdQuery(Guid Id) : IRequest<GetPackageByIdQueryResponse>;

    public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, GetPackageByIdQueryResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetPackageByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<GetPackageByIdQueryResponse> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var Package = FilterIfPackageExsists(request.Id);

            var result = _mapper.Map<GetPackageByIdQueryResponse>(Package);
            return result;
        }

        private Package FilterIfPackageExsists(Guid id)
            => _dbContext.Packages
                .Find(id)
                     ?? throw new NotFoundException(
                            " There is no Package with this Id. ");


    }

    public class GetPackageByIdQueryResponse
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
