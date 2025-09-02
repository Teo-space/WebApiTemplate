namespace WebApiTemplate.Core.Output.Models.Orders;

public sealed record OrdersListModel
{
	public int Count { get; init; }

	public IReadOnlySet<OrderModel> Orders { get; init; } = new HashSet<OrderModel>();
}
