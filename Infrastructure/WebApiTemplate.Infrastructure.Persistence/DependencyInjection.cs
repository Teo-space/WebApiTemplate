using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiTemplate.Core.Interfaces.Infrastructure.Repositories;
using WebApiTemplate.Infrastructure.Persistence.EntityFramework.DbContexts;
using WebApiTemplate.Infrastructure.Persistence.Repositories;

namespace WebApiTemplate.Infrastructure.Persistence;

public static class DependencyInjection
{
	public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
	{
		builder.Services.AddPersistence(builder.Configuration);

		return builder;
	}

	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<StoreDbContext>(options => options
			.UseSqlServer(configuration
			.GetConnectionString(ConnectionNames.Store)));

		services.AddPersistenceCommon();

		return services;
	}

	internal static IServiceCollection AddPersistenceCommon(this IServiceCollection services)
	{
		services.AddScoped<IOrderServiceRepository, OrderServiceRepository>();

		return services;
	}
}
