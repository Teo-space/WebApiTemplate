namespace WebApiTemplate.Tests.Unit.AggregateParts;

public abstract record BaseTest<TService> where TService : class
{
	protected Aggregate<TService> Aggregate { get; init; } = AggregateFactory.Create<TService>();
	protected TService Service => Aggregate.Service;
}
