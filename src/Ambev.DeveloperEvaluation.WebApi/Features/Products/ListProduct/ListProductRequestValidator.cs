using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct
{
    public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
    {
        public ListProductRequestValidator()
        {
            RuleFor(x => x.PageIndex)
                .NotEmpty()
                .WithMessage("Page Index is required");
        }
    }
}
