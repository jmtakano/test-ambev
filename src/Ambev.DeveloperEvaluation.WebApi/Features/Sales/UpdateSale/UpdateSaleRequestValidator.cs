using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.Items).NotEmpty();

            RuleForEach(x => x.Items)
             .Must(item => item.Quantity <= 20)
             .WithMessage($"Não é permitido vender mais de 20 unidades do mesmo produto.");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("A venda deve conter pelo menos um item.");
        }
    }
}
