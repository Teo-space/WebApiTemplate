using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Core.Input.Models.Orders;
using WebApiTemplate.Core.Interfaces.Services;
using WebApiTemplate.Core.Output.Models.Orders;

namespace WebApiTemplate.Api.Controllers;

[ApiController, Route($"{ServiceName}/v1/[controller]")]
public class OrderController(IOrderService OrderService) : ControllerBase
{
	/// <summary>
	/// Метод выдачи списка заказов
	/// </summary>
	[HttpGet]
	[ProducesResponseType(typeof(OrdersListModel), StatusCodes.Status200OK)]
	public async Task<ActionResult> GetCatalogGroups([FromQuery] GetOrdersInput input)
	{
		var result = await OrderService.GetOrdersAsync(input);

		return Ok(result);
	}

}
