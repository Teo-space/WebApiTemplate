using WebApiTemplate.Core.Domain.Models.Store;
using WebApiTemplate.Core.Output.Models.Orders;

namespace WebApiTemplate.Core.Services.Mappers;

internal static class OrderServiceMapper
{
	public static IReadOnlySet<OrderModel> Map(this IEnumerable<Order> orders) => orders.Select(Map).ToHashSet();

	public static OrderModel Map(this Order order)
	{
		return new OrderModel
		{
			OrderId = order.OrderId,
			UserId = order.UserId,
			Date = order.Date,
			DeliveryType = order.DeliveryType,
		};
	}
}
