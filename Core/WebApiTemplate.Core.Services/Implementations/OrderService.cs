using WebApiTemplate.Core.Domain.Models.Store;
using WebApiTemplate.Core.Input.Models.Orders;
using WebApiTemplate.Core.Interfaces.Infrastructure.Repositories;
using WebApiTemplate.Core.Interfaces.Services;
using WebApiTemplate.Core.Output.Models.Orders;
using WebApiTemplate.Core.Services.Mappers;

namespace WebApiTemplate.Core.Services.Implementations;

internal sealed record OrderService(IOrderServiceRepository OrderServiceRepository) : IOrderService
{
	public async Task<OrdersListModel> GetOrdersAsync(GetOrdersInput input)
	{
		IReadOnlyCollection<Order> orders = await OrderServiceRepository.GetOrdersAsync(input.UserId);

		return new OrdersListModel
		{
			Count = orders.Count,
			Orders = orders.Map()
		};
	}
}
