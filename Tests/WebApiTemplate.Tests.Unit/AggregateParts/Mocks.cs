using Moq;
using WebApiTemplate.Core.Interfaces.Infrastructure.Services;
using WebApiTemplate.Core.Interfaces.Infrastructure.Services.Models;

namespace WebApiTemplate.Tests.Unit.AggregateParts;

/// <summary>
/// При необходимости добавить еще моки
/// </summary>
public sealed record Mocks
{
	public Mock<ISomeInfrastructureService> SomeInfrastructureServiceMock { get; init; }
	public ISomeInfrastructureService SomeInfrastructureService => SomeInfrastructureServiceMock.Object;


	public void SomeInfrastructureService_Get(string name, SomeExternalModel someExternalModel)
	{
		SomeInfrastructureServiceMock.Setup(x => x.Get(name)).Returns(async (string name) => someExternalModel);
	}
}
