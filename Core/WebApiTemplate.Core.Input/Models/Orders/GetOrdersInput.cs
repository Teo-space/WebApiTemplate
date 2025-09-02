namespace WebApiTemplate.Core.Input.Models.Orders;

public sealed record GetOrdersInput
{
	public int UserId { get; init; }

}
