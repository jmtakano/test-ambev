using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            //Add validations:
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.SaleNumber).NotEmpty();
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
