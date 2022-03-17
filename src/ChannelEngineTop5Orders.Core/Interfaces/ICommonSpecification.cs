using System.Threading.Tasks;

namespace ChannelEngineTop5Orders.Core.Interfaces
{
	public interface ICommonSpecification<in T>
	{
		Task<IResponseContainer> IsSatisfiedBy(T subject);
	}
}
