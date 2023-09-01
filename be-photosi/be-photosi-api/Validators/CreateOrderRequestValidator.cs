using be_photosi_api.Common;
using be_photosi_api.Handlers.Command;
using FluentValidation;

namespace be_photosi_api.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.Products).NotEmpty().WithMessage(ErrorMessages.MISSING_PRODUCTS);
        }
    }
}
