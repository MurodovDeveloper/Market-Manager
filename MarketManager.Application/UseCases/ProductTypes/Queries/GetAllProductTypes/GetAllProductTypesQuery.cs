using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.ProductTypes.Queries.GetAllProductTypes;

public record GetAllProductTypesQuery : IRequest<IEnumerable<GetAllProductTypesQueryResponse>>;

public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<GetAllProductTypesQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetAllProductTypesQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<IEnumerable<GetAllProductTypesQueryResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ProductType> productsTypes = _context.ProductTypes;

        return Task.FromResult(_mapper.Map<IEnumerable<GetAllProductTypesQueryResponse>>(productsTypes));
    }

}

public class GetAllProductTypesQueryResponse
{
    public string Name { get; set; }
}



