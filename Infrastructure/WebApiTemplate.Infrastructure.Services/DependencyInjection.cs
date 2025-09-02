using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTemplate.Core.Interfaces.Infrastructure.Services;
using WebApiTemplate.Infrastructure.Services.Implementations;

namespace WebApiTemplate.Infrastructure.Services;

public static class DependencyInjection
{
	public static IHostApplicationBuilder AddExternalServices(this IHostApplicationBuilder builder)
	{
		builder.Services.AddExternalServices(builder.Configuration);

		return builder;
	}

	public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddTransient<ISomeInfrastructureService, SomeInfrastructureService>();

		return services;
	}
}
