using FluentValidation;
using MarketManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandValidation : AbstractValidator<UpdatePermissionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePermissionCommandValidation(IApplicationDbContext context)
        {
            _context = context;
        }

        public UpdatePermissionCommandValidation()
        {
            RuleFor(x => x.Name)
                .Must(BeUniqueName).WithMessage("Permission names must be unique.")
                .NotEmpty().WithMessage("Permission name must not be empty!")
                .MaximumLength(255).WithMessage("Permission name cannot exceed 255 characters.");
        }
        private bool BeUniqueName(string name)
        {
            // Implement your logic to check if the name is unique in the data store.
            // For example, using the _permissionRepository to query the database.
            // Return true if the name is unique, otherwise return false.

            // Example (assuming the repository has a method to check uniqueness):
            return _context.Permissions.FirstOrDefault(x => x.Name == name) == null;
        }
    }
}
