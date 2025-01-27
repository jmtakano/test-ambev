using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale
{
    public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
    {
        public ListSaleRequestValidator()
        {
            RuleFor(x => x.PageIndex)
             .NotEmpty()
             .WithMessage("Page Index is required");
        }
    }
}
