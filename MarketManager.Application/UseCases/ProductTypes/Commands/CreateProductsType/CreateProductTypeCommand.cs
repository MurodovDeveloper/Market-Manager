using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.ProductTypes.Commands.CreateProductsType;

public class CreateProductTypeCommand : IRequest<Guid>
{
    public string Name { get; set; }
}
public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public CreateProductTypeCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        ProductType producttype = _mapper.Map<ProductType>(request);
        await _context.ProductTypes.AddAsync(producttype, cancellationToken);
        await _context.SaveChangesAsync();
        return producttype.Id;

    }


}