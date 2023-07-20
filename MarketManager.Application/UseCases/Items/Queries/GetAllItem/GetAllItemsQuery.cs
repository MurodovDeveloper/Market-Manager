using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Items.Queries.GetAllItems
{
    public record GetAllItemsQuery : IRequest<IEnumerable<GetAllItemsQueryResponse>>;

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<GetAllItemsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllItemsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<GetAllItemsQueryResponse>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Item> items = _context.Items;

            return Task.FromResult(_mapper.Map<IEnumerable<GetAllItemsQueryResponse>>(items));

        }
    }
    public class GetAllItemsQueryResponse
    {
        public Guid PackageId { get; set; }
        public Guid OrderId { get; set; }
        public double Count { get; set; }
        public double SoldPrice { get; set; }
    }
}
