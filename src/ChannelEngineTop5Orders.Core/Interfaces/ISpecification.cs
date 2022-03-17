using ChannelEngineTop5Orders.Core.Core.Domain;

namespace ChannelEngineTop5Orders.Core.Core.Interfaces
{
	public interface ISpecification<in T, TId> where T : EntityBase<TId>
	{
		IResponseContainer IsSatisfiedBy(T entity);
	}
}