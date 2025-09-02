using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApiTemplate.Core.Interfaces.Infrastructure.Services;
using WebApiTemplate.Core.Services;
using WebApiTemplate.Infrastructure.Persistence;
using WebApiTemplate.Infrastructure.Persistence.EntityFramework.DbContexts;

namespace WebApiTemplate.Tests.Unit.AggregateParts;

public static class AggregateFactory
{
	public static Aggregate<T> Create<T>(bool useInMemoryDatabase = false) where T : class
	{
		IServiceCollection services = new ServiceCollection();

		{
			/// <summary>
			/// При необходимости добавить еще контексты
			/// </summary>
			services.AddTestDbContext<StoreDbContext>(useInMemoryDatabase);

			services.AddLogging();

			services.AddPersistenceCommon();
			services.AddServices();
		}

		Mocks mocks = services.GetMocks();

		IServiceProvider serviceProvider = services.BuildServiceProvider();
		IServiceScope serviceScope = serviceProvider.CreateScope();
		IServiceProvider scopeServiceProvider = serviceScope.ServiceProvider;

		T service = scopeServiceProvider.GetRequiredService<T>();

		return new Aggregate<T>
		{
			ServiceProvider = scopeServiceProvider,
			ServiceScope = serviceScope,
			Service = service,
			DbContexts = serviceScope.GetDbContexts(),
			Mocks = mocks
		};
	}

	/// <summary>
	/// При необходимости добавить еще моки
	/// </summary>
	public static Mocks GetMocks(this IServiceCollection services)
	{
		Mocks mocks = new Mocks
		{
			SomeInfrastructureServiceMock = new Mock<ISomeInfrastructureService>(),
		};
		{
			services.AddScoped(x => mocks.SomeInfrastructureService);
		}

		return mocks;
	}

	/// <summary>
	/// При необходимости добавить еще контексты
	/// </summary>
	public static DbContexts GetDbContexts(this IServiceScope serviceScope)
	{
		return new DbContexts
		{
			StoreDbContext = serviceScope.GetRequiredDbContext<StoreDbContext>(),
		};
	}

	public static void AddTestDbContext<TDbContext>(this IServiceCollection services, bool useInMemoryDatabase) where TDbContext : DbContext
	{
		if (useInMemoryDatabase)
		{
			services.AddDbContext<TDbContext>(options => options.UseInMemoryDatabase($"Db_{Guid.NewGuid()}"));
		}
		else
		{
			services.AddDbContext<TDbContext>(options => options.UseTestDb());
		}
	}

	public static TDbContext GetRequiredDbContext<TDbContext>(this IServiceScope serviceScope) where TDbContext : DbContext
	{
		TDbContext DbContext = serviceScope.ServiceProvider.GetRequiredService<TDbContext>();

		DbContext.Database.EnsureCreated();

		return DbContext;
	}

}
