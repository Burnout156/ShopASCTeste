using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopASCLibrary.Models;

namespace ShopASCLibrary.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(o => o.ShippingAddress).IsRequired().HasMaxLength(255);

            // Configurar a relação um para muitos (um Pedido tem muitos Produtos)
            builder.HasMany(o => o.OrderProducts)
                .WithOne()
                .HasForeignKey(p => p.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Orders");
        }
    }
}
