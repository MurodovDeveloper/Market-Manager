using FluentValidation;

namespace MarketManager.Application.UseCases.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty()
               .NotNull()
               .WithMessage("Product id is required.");

            RuleFor(t => t.ProductTypeId).NotEmpty()
                .NotNull()
                .WithMessage("Product Type id is required.");

            RuleFor(d => d.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Name is required");

            RuleFor(d => d.Description)
                .NotEmpty()
                .MaximumLength(250)
                .WithMessage("Description is required");
        }
    }
}
