using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Core.Handlers
{
	public interface ICommandHandler<in T>
	{
		Task<IResponseContainer> HandleAsync(T command);
	}
}
