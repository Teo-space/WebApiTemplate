using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Core.Domain.Models.Store;

namespace WebApiTemplate.Infrastructure.Persistence.EntityFramework.DbContexts;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
	public DbSet<Order> Orders { get; set; }

#if DEBUG
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

		optionsBuilder.EnableSensitiveDataLogging();
		optionsBuilder.LogTo(Console.WriteLine, minimumLevel: Microsoft.Extensions.Logging.LogLevel.Information);
	}
#endif

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		string dbContextConfigurationsNamespace = "EntityFramework.Configurations.StoreDbContext";

		if (Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(t => string.IsNullOrEmpty(t.Namespace) == false)
			.Where(t => t.Namespace.Contains(dbContextConfigurationsNamespace))
			.Any() == false)
		{
			throw new Exception("Configure namespace for StoreDbContext configurations!");
		}
		else
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
				type => type?.Namespace?.Contains(dbContextConfigurationsNamespace) ?? false);
		}
	}
}
