using MediatR;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Command.UpdateOrder
{
    public sealed record UpdateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public decimal Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public string? Text { get; set; }
    }

    public enum OrderType
    {
        Market = 0,
        Limit = 1,
    }
}