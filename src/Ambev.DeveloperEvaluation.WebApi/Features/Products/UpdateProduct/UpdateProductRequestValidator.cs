using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Category).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
        }
    }
}
