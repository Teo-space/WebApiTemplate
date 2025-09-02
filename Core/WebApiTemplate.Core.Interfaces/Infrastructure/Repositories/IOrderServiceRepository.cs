using WebApiTemplate.Core.Domain.Models.Store;

namespace WebApiTemplate.Core.Interfaces.Infrastructure.Repositories;

public interface IOrderServiceRepository
{
	public Task<IReadOnlyCollection<Order>> GetOrdersAsync(int userId);
}