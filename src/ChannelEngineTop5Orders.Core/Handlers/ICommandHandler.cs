using ChannelEngineTop5Orders.Core.Core.Interfaces;
using System.Threading.Tasks;

namespace ChannelEngineTop5Orders.Core.Core.Handlers
{
	public interface ICommandHandler<in T>
	{
		Task<IResponseContainer> HandleAsync(T command);
	}
}
