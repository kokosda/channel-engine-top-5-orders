using System.Threading.Tasks;

namespace ChannelEngineTopSellingProducts.Core.Interfaces
{
	public interface ICommonSpecification<in T>
	{
		Task<IResponseContainer> IsSatisfiedBy(T subject);
	}
}
