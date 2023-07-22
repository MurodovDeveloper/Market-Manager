using FluentValidation;

namespace MarketManager.Application.UseCases.Packages.Commands.CreatePackage
{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public CreatePackageCommandValidator()
        {
            RuleFor(t => t.ProductId).NotEmpty()
                .NotNull()
                .WithMessage("Product id is required.");

            RuleFor(t => t.SupplierId).NotEmpty()
                .NotNull()
                .WithMessage("Supplier id is required.");

            RuleFor(t => t.IncomingCount)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("IncomingCount is required.");

            RuleFor(t => t.IncomingPrice)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("IncomingPrice is required.");

            RuleFor(t => t.SalePrice)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("SalePrice is required.");

            RuleFor(t => t.IncomingDate)
                .NotNull()
                .WithMessage("Working date is required.");
        }
    }
}