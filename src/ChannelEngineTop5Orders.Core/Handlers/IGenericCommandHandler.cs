using ChannelEngineTop5Orders.Core.Core.Interfaces;
using System.Threading.Tasks;

namespace ChannelEngineTop5Orders.Core.Core.Handlers
{
	public interface IGenericCommandHandler<in TCommand, TResult>
	{
		Task<IResponseContainerWithValue<TResult>> HandleAsync(TCommand command);
	}
}
