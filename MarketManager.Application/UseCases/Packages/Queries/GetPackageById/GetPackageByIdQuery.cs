using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Packages.Response;
using MarketManager.Domain.Entities;
using MediatR;

namespace MarketManager.Application.UseCases.Packages.Queries.GetPackageById
{
    public record GetPackageByIdQuery(Guid Id) : IRequest<PackageResponse>;

    public class GetPackageByIdQueryHandler : IRequestHandler<GetPackageByIdQuery, PackageResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetPackageByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<PackageResponse> Handle(GetPackageByIdQuery request, CancellationToken cancellationToken)
        {
            var Package = FilterIfPackageExsists(request.Id);

            var result = _mapper.Map<PackageResponse>(Package);
            return result;
        }

        private Package FilterIfPackageExsists(Guid id)
            => _dbContext.Packages
                .Find(id)
                     ?? throw new NotFoundException(
                            " There is no Package with this Id. ");


    }
}
