using Microsoft.EntityFrameworkCore;

using WebApiTemplate.Core.Domain.Models.Store;
using WebApiTemplate.Core.Interfaces.Infrastructure.Repositories;
using WebApiTemplate.Infrastructure.Persistence.EntityFramework.DbContexts;

namespace WebApiTemplate.Infrastructure.Persistence.Repositories;

internal sealed record OrderServiceRepository(StoreDbContext StoreDbContext) : IOrderServiceRepository
{
	public async Task<IReadOnlyCollection<Order>> GetOrdersAsync(int userId)
	{
		return await StoreDbContext.Orders.Where(x => x.UserId == userId).ToListAsync();
	}
}
