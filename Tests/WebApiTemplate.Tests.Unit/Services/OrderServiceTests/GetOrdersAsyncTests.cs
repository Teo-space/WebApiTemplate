using WebApiTemplate.Core.Input.Models.Orders;
using WebApiTemplate.Core.Interfaces.Services;
using WebApiTemplate.Core.Output.Models.Orders;
using WebApiTemplate.Tests.Unit.AggregateParts;
using WebApiTemplate.Tests.Unit.FactoryExtensions;

namespace WebApiTemplate.Tests.Unit.Services.OrderServiceTests;

public sealed record GetOrdersAsyncTests : BaseTest<IOrderService>
{
	const int orderId = 911;

	public GetOrdersAsyncTests()
	{
		Aggregate.DbContexts.AddOrder(UserId, orderId);
	}

	[Fact]
	public async Task Test()
	{
		GetOrdersInput input = new GetOrdersInput
		{
			UserId = UserId
		};

		OrdersListModel ordersListModel = await Service.GetOrdersAsync(input);

		ordersListModel.ShouldNotBeNull();

		ordersListModel.Count.ShouldBe(1);
		ordersListModel.Orders.ShouldNotBeNull().ShouldNotBeEmpty();
	}
}