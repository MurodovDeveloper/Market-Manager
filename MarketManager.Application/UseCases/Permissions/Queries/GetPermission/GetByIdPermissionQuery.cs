using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Permissions.Queries.GetPermission
{
    public record GetByIdPermissionQuery(Guid PermissionId):IRequest<PermissionResponse>;

    public class GetByIdPermissionQueryHandler : IRequestHandler<GetByIdPermissionQuery, PermissionResponse>
    {
        public readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByIdPermissionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PermissionGetDto> Handle(GetByIdPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission =await _dbContext.Permissions.FindAsync(new object[] {request.PermissionId},cancellationToken);
            if (permission == null)
            {
                throw new NotFoundException(nameof(Permission), request.PermissionId);
            }
            var result = _mapper.Map<PermissionGetDto>(permission);
            return result;
        }
    }
}
