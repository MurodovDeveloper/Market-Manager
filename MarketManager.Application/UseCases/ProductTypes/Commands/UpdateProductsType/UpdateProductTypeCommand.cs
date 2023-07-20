using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.ProductsType.Commands.UpdateProductType;

public class UpdateProductTypeCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}
public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public UpdateProductTypeCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
    {
        var productType = await _context.ProductTypes.FindAsync(request.Id);
        _mapper.Map(productType, request);

        if (productType == null)
        {
            throw new NotFoundException(nameof(productType), request.Id);
        }
        productType.Name = request.Name;
        await _context.SaveChangesAsync();
    }


}
