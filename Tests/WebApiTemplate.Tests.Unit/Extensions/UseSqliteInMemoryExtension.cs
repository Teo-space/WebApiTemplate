using Microsoft.EntityFrameworkCore;

public static class UseSqliteInMemoryExtension
{
	public static DbContextOptionsBuilder<TDbContext> UseTestDb<TDbContext>(this DbContextOptionsBuilder<TDbContext> optionsBuilder)
		where TDbContext : DbContext
	{
		optionsBuilder.UseSqlite($"DataSource=file:DbContext_{Guid.NewGuid()}?mode=memory&cache=shared");
		return optionsBuilder;
	}

	public static DbContextOptionsBuilder UseTestDb(this DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite($"DataSource=file:DbContext_{Guid.NewGuid()}?mode=memory&cache=shared");
		return optionsBuilder;
	}
}
