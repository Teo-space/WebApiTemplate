using WebApiTemplate.Infrastructure.Persistence.EntityFramework.DbContexts;

namespace WebApiTemplate.Tests.Unit.AggregateParts;

/// <summary>
/// При необходимости добавить еще контексты
/// </summary>
public sealed record DbContexts : IDisposable
{
	public required StoreDbContext StoreDbContext { get; init; }

	public void Dispose()
	{
		StoreDbContext?.Dispose();
	}

	public void ChangeTrackerClear()
	{
		StoreDbContext?.ChangeTracker.Clear();
	}

	public void EnsureDeleted()
	{
		StoreDbContext?.Database.EnsureDeleted();
	}

	public void EnsureCreated()
	{
		StoreDbContext?.Database.EnsureCreated();
	}
}
