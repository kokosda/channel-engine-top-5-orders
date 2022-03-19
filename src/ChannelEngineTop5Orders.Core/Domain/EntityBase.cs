namespace ChannelEngineTop5Orders.Core.Domain
{
	public abstract class EntityBase<TId> where TId: new()
	{
		public TId Id { get; init; } = new();
	}
}
