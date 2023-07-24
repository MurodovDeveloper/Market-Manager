using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Items.Queries.GetAllItems
{
    public record GetAllItemsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<GetAllItemsQueryResponse>>;

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<GetAllItemsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllItemsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<List<GetAllItemsQueryResponse>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Item> items = _context.Items;

            return Task.FromResult(_mapper.Map<List<GetAllItemsQueryResponse>>(items));

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
