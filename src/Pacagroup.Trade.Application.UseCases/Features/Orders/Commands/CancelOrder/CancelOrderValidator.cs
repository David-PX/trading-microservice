using FluentValidation;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CancelOrder
{
    public class CancelOrderValidator : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}