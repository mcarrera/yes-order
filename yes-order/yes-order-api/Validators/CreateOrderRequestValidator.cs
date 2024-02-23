using yes_orders_api.Common;
using yes_orders_api.Handlers.Command;
using FluentValidation;

namespace yes_orders_api.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.Products).NotEmpty().WithMessage(ErrorMessages.MISSING_PRODUCTS);
        }
    }
}
