using FluentValidation;
using MarketManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.ExpiredProducts.Command.DeleteExpiredProduct
{
    public class DeleteExpiredProductCommandValidator : AbstractValidator<DeleteExpiredProductCommand>
    {
        public DeleteExpiredProductCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
