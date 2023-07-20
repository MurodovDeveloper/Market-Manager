using AutoMapper;
using FluentValidation.Validators;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommand: IRequest<IEnumerable<PermissionResponse>>
    {
        public string[] Name { get; set; }
    }
    public class CreatePermissionCommandHanler : IRequestHandler<CreatePermissionCommand, IEnumerable<PermissionResponse>>
    {
        private IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreatePermissionCommandHanler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionResponse>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {

            var _permissions = new List<Permission>();

            foreach (string item in request.Name)
            {
                _permissions.Add(new()
                {
                    Name = item
                });
            }

            await _dbContext.Permissions.AddRangeAsync(_permissions, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<PermissionResponse>>(_permissions);
            return result;
        }
    }
}
