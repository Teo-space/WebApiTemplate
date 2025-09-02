using WebApiTemplate.Core.Domain.Enums;
using WebApiTemplate.Core.Domain.Models.Store;
using WebApiTemplate.Tests.Unit.AggregateParts;
using WebApiTemplate.Tests.Unit.Extensions;

namespace WebApiTemplate.Tests.Unit.FactoryExtensions;

internal static class OrdersDbContextsExtensions
{
	public static void AddOrder(this DbContexts dbContexts, int userId, int orderId, DeliveryType deliveryType = DeliveryType.Storehouse)
	{
		Order order = new Order
		{
			OrderId = orderId,
			UserId = userId,
			Date = DateTime.Now,
			DeliveryType = deliveryType
		};

		dbContexts.StoreDbContext.AddAndSave(order);
	}
}
