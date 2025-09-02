using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTemplate.Core.Interfaces.Services;
using WebApiTemplate.Core.Services.Implementations;

namespace WebApiTemplate.Core.Services;

public static class DependencyInjection
{
	public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
	{
		builder.Services.AddServices();

		return builder;
	}

	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddTransient<IOrderService, OrderService>();

		return services;
	}
}
