using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleForEach(x => x.Items)
                .Must(item => item.Quantity <= 20)
                .WithMessage("Não é permitido vender mais de 20 unidades do mesmo produto. Produto: {PropertyValue}");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("A venda deve conter pelo menos um item.");

        }
    }
}
