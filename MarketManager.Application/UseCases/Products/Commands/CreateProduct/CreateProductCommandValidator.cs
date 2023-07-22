using FluentValidation;

namespace MarketManager.Application.UseCases.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
          
        }
    }
}
