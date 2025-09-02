using WebApiTemplate.Core.Domain.Enums;

namespace WebApiTemplate.Core.Domain.Models.Store;

public sealed record Order
{
	public int OrderId { get; set; }

	public int UserId { get; set; }

	public DateTime Date { get; set; }

	public DeliveryType DeliveryType { get; set; }

}
