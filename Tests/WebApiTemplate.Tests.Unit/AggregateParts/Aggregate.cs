using Microsoft.Extensions.DependencyInjection;

namespace WebApiTemplate.Tests.Unit.AggregateParts;

public record Aggregate<T> : IDisposable where T : class
{
	public required IServiceProvider ServiceProvider { get; init; }
	public required IServiceScope ServiceScope { get; init; }
	public required T Service { get; init; }

	public required DbContexts DbContexts { get; init; }
	public required Mocks Mocks { get; init; }

	public void Dispose() => DbContexts?.Dispose();

	public static implicit operator T(Aggregate<T> aggregate) => aggregate.Service;
}
