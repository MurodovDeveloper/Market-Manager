using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.PaymentTypes.Queries.GetByIdPaymentType
{
    public class GetByIdPaymentTypeQuery:IRequest<GetByIdPaymentTypeQueryResponse>
    {
        public Guid Id { get; set; }
    }
    public class GetByIdPaymentTypeQueryHandler : IRequestHandler<GetByIdPaymentTypeQuery, GetByIdPaymentTypeQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetByIdPaymentTypeQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetByIdPaymentTypeQueryResponse> Handle(GetByIdPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            PaymentType? paymentType = await _context.PaymentTypes.FindAsync(request.Id);
            if (paymentType == null) throw new NotFoundException(nameof(PaymentType), request.Id);

            GetByIdPaymentTypeQueryResponse? mapped = _mapper.Map<GetByIdPaymentTypeQueryResponse>(paymentType);
            return mapped;
        }
    }

    public class GetByIdPaymentTypeQueryResponse
    {
        public string Name { get; set; }
    }
}
