using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.PaymentTypes.Queries.GetAllPaymentType
{
    public class GetAllPaymentTypeQuery : IRequest<IEnumerable<GetAllPaymentTypeQueryResponse>>
    {

    }

    public class GetAllPaymentTypeQueryHandler : IRequestHandler<GetAllPaymentTypeQuery, IEnumerable<GetAllPaymentTypeQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllPaymentTypeQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<GetAllPaymentTypeQueryResponse>> Handle(GetAllPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<PaymentType> paymentTypes = _context.PaymentTypes;
            IEnumerable<GetAllPaymentTypeQueryResponse> response = _mapper.Map<IEnumerable<GetAllPaymentTypeQueryResponse>>(paymentTypes);
            return await Task.FromResult(response);
        }
    }

    public class GetAllPaymentTypeQueryResponse
    {
        public string Name { get; set; }
    }
}
