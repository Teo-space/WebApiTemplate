using Microsoft.EntityFrameworkCore;

namespace WebApiTemplate.Tests.Unit.Extensions;

internal static class DbContextExtensions
{
	public static void AddAndSave<TEntity>(this DbContext dbContext, TEntity entity) where TEntity : class
	{
		dbContext.Set<TEntity>().Add(entity);

		dbContext.SaveChanges();

		dbContext.ChangeTracker.Clear();
	}

	public static void AddRangeAndSave<TEntity>(this DbContext dbContext, params TEntity[] entities) where TEntity : class
	{
		dbContext.Set<TEntity>().AddRange(entities);

		dbContext.SaveChanges();

		dbContext.ChangeTracker.Clear();
	}
}
