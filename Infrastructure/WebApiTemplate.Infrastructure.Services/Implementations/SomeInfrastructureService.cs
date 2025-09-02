using Microsoft.Extensions.Configuration;
using WebApiTemplate.Core.Interfaces.Infrastructure.Services;
using WebApiTemplate.Core.Interfaces.Infrastructure.Services.Models;

namespace WebApiTemplate.Infrastructure.Services.Implementations;

internal sealed record SomeInfrastructureService(IConfiguration Configuration) : ISomeInfrastructureService
{
	public Task<SomeExternalModel> Get(string name)
	{
		return Task.FromResult(new SomeExternalModel { Id = 1, Name = name });
	}
}
