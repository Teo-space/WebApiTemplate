using WebApiTemplate.Core.Input.Models.Orders;
using WebApiTemplate.Core.Output.Models.Orders;

namespace WebApiTemplate.Core.Interfaces.Services;

public interface IOrderService
{
	Task<OrdersListModel> GetOrdersAsync(GetOrdersInput input);
}
