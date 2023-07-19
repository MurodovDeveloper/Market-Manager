using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Suppliers.Queries.GetSupplierById
{
    public record GetSupplierByIdQuery(Guid Id) : IRequest<GetSupplierByIdQueryRespnse>;

    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdQueryRespnse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetSupplierByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetSupplierByIdQueryRespnse> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            Supplier? supplier = await _context.Suppliers.FindAsync(request.Id);

            if (supplier is null)
                throw new NotFoundException(nameof(Supplier), request.Id);

            return _mapper.Map<GetSupplierByIdQueryRespnse>(supplier);
        }
    }

    public class GetSupplierByIdQueryRespnse
    {
        public Guid Id { get; set; }
    }
}
