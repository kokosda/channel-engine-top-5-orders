using System.Threading.Tasks;

namespace ChannelEngineTop5Orders.Core.Core.Interfaces
{
	public interface ICommonSpecification<in T>
	{
		Task<IResponseContainer> IsSatisfiedBy(T subject);
	}
}
