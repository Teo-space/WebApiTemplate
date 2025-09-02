using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTemplate.Core.Domain.Models.Store;

namespace WebApiTemplate.Infrastructure.Persistence.EntityFramework.Configurations.StoreDbContext;

public class OrderEfConfig : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.ToTable("ORDER");
		builder.HasKey(x => x.OrderId);

		builder.Property(x => x.OrderId).HasColumnName("ORDER_ID");

		builder.Property(x => x.UserId).HasColumnName("USER_ID");

		builder.Property(x => x.Date).HasColumnName("DATE");

		builder.Property(x => x.DeliveryType).HasColumnName("DELIVERY_TYPE");
	}
}
