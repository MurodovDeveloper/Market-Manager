using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Permissions.Queries.GetAllPermissions
{
    public record GetAllPermissionQuery:IRequest<IEnumerable<PermissionGetDto>>;
    public class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, IEnumerable<PermissionGetDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllPermissionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionGetDto>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Permission> permissions = await _dbContext.Permissions.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<PermissionGetDto>>(permissions);
            return result;
        }
    }
}
