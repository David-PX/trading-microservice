using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Persistence.Seeders
{
    public class OrderSeeder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = 1,
                    Symbol = "META",
                    Side = Domain.Enums.OrderSide.Buy,
                    TransacTime = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    Quanty = 1000,
                    Type = Domain.Enums.OrderType.Limit,
                    Price = 522.99M,
                    Currency = "USD",
                    Text = "",
                    Created = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "System"
                },
                new Order
                {
                    Id = 2,
                    Symbol = "MSFT",
                    Side = Domain.Enums.OrderSide.Buy,
                    TransacTime = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    Quanty = 300,
                    Type = Domain.Enums.OrderType.Limit,
                    Price = 424.30M,
                    Currency = "USD",
                    Text = "",
                    Created = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "System"
                },
                new Order
                {
                    Id = 3,
                    Symbol = "AMZN",
                    Side = Domain.Enums.OrderSide.Sell,
                    TransacTime = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    Quanty = 400,
                    Type = Domain.Enums.OrderType.Market,
                    Price = 0,
                    Currency = "USD",
                    Text = "",
                    Created = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "System"
                },
                new Order
                {
                    Id = 4,
                    Symbol = "TSLA",
                    Side = Domain.Enums.OrderSide.Sell,
                    TransacTime = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    Quanty = 800,
                    Type = Domain.Enums.OrderType.Market,
                    Price = 0,
                    Currency = "USD",
                    Text = "",
                    Created = new DateTime(2025, 6, 12, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "System"
                });
        }
    }
}