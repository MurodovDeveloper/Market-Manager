using AutoMapper;
using MarketManager.Application.Common.Abstraction;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.ExpiredProducts.Queries.GetAllExpiredProducts
{
    public class GetAllExpiredProductsQuery : IRequest<IEnumerable<GetAllExpiredProductsResponce>>
    {
    }

    public class GetAllExpiredProductsResponce : ExpiredProductBaseResponce
    {
       
    }

    public class GetAllExpiredProductsQueryHandler 
        : IRequestHandler<GetAllExpiredProductsQuery, IEnumerable<GetAllExpiredProductsResponce>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllExpiredProductsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<GetAllExpiredProductsResponce>> Handle
            (GetAllExpiredProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ExpiredProduct> expiredProducts = _context.ExpiredProducts;

            return Task.FromResult(_mapper.Map<IEnumerable<GetAllExpiredProductsResponce>>(expiredProducts));
        }
    }
}
