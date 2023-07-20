using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.ExpiredProducts.Command.UpdateExpiredProduct
{
    public class UpdateExpiredProductCommandValidator : AbstractValidator<UpdateExpiredProductCommand>
    {
        public UpdateExpiredProductCommandValidator()
        {
            RuleFor(c=>c.Id).NotEmpty();
            RuleFor(c=>c.PackageId).NotEmpty();
            RuleFor(c=>c.Count).NotEmpty();
        }
    }
}
