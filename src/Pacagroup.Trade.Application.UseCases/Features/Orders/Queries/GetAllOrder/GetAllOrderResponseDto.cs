namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder
{ 
    public class GetAllOrderResponseDto
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public OrderSide Side { get; set; }
        public DateTime TransacTime { get; set; }
        public decimal Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public string? Text { get; set; }
    }
    
    public enum OrderSide
    {
        Buy = 0,
        Sell = 1
    }

    public enum OrderType
    {
        Market = 0,
        Limit = 1,
    }
}
