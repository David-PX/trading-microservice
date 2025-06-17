using MediatR;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Command.CancelOrder
{
    public sealed record CancelOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}