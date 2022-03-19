using ChannelEngineTopSellingProducts.Core.Domain;

namespace ChannelEngineTopSellingProducts.Core.Interfaces
{
	public interface ISpecification<in T, TId> where T : EntityBase<TId> where TId: new()
	{
		IResponseContainer IsSatisfiedBy(T entity);
	}
}