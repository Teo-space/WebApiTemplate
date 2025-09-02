using WebApiTemplate.Core.Domain.Enums;

namespace WebApiTemplate.Core.Output.Models.Orders;

public sealed record OrderModel
{
	public int OrderId { get; set; }

	public int UserId { get; set; }

	public DateTime Date { get; set; }

	public DeliveryType DeliveryType { get; set; }
}
