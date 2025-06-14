using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasPrecision(9, 0)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(t => t.Symbol)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Side)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(t => t.TransacTime)
                .IsRequired();

            builder.Property(t => t.Quanty)
                .HasPrecision(9, 0)
                .IsRequired();

            builder.Property(t => t.Type)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(t => t.Price)
                .HasPrecision(9, 4)
                .IsRequired();

            builder.Property(t => t.Currency)
                .IsRequired()
                .HasMaxLength(3)
                .HasDefaultValue("USD");

            builder.Property(t => t.Text)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(t => t.Created)
                .IsRequired();

            builder.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(t => t.LastModified)
                .IsRequired(false);

            builder.Property(t => t.LastModifiedBy)
                .IsRequired(false)
                .HasMaxLength(120);            
        }
    }
}