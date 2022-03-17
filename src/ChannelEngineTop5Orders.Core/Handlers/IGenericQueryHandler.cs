using ChannelEngineTop5Orders.Core.Core.Interfaces;
using System.Threading.Tasks;

namespace ChannelEngineTop5Orders.Core.Core.Handlers
{
	public interface IGenericQueryHandler<in TQuery, TResult>
	{
		Task<IResponseContainerWithValue<TResult>> HandleAsync(TQuery query);
	}
}
