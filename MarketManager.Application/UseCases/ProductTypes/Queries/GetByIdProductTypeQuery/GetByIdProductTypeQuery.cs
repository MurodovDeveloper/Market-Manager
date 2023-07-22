using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.ProductTypes.Queries.GetByIdProductTypeQuery;

public record GetByIdProductTypeQuery(Guid Id) : IRequest<GetByIdProductTypeQueryResponce>;

public class GetByIdProductTypeQueryHandler : IRequestHandler<GetByIdProductTypeQuery, GetByIdProductTypeQueryResponce>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetByIdProductTypeQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<GetByIdProductTypeQueryResponce> Handle(GetByIdProductTypeQuery request, CancellationToken cancellationToken)
    {
        ProductType productType = await _context.ProductTypes.FindAsync(request.Id);
        if (productType is null)
            throw new NotFoundException(nameof(ProductsType), request.Id);

        return _mapper.Map<GetByIdProductTypeQueryResponce>(productType);
    }

}
public class GetByIdProductTypeQueryResponce
{
    public Guid Id { get; set; }
}
