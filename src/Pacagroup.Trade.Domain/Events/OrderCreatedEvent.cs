using Pacagroup.Trade.Domain.Commons;
using Pacagroup.Trade.Domain.Enums;

namespace Pacagroup.Trade.Domain.Events
{
    public class OrderCreatedEvent : BaseEvent
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public OrderSide Side { get; set; }
        public DateTime TransacTime { get; set; }
        public decimal Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string? Text { get; set; }
    }
}