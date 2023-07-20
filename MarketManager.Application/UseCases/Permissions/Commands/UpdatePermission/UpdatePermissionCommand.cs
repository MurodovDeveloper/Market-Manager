using AutoMapper;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
    {
        public readonly IApplicationDbContext _dbContext;

        public UpdatePermissionCommandHandler(IApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _dbContext.Permissions.FindAsync(new object[] { request.Id }, cancellationToken);

            if(permission is null)
            {
                throw new NotFoundException(nameof(Permission), request.Id);
            }

            permission.Roles.Clear();
            permission.Name = request.Name;
            _dbContext.Permissions.Update(permission);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
