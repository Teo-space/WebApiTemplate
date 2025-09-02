using WebApiTemplate.Core.Interfaces.Infrastructure.Services.Models;

namespace WebApiTemplate.Core.Interfaces.Infrastructure.Services;

public interface ISomeInfrastructureService
{
	/// <summary>
	/// Имитируется вызов какого внешнего сервиса
	/// </summary>
	public Task<SomeExternalModel> Get(string name);
}
