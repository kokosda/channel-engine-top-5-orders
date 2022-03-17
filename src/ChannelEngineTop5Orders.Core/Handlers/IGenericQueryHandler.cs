using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Interfaces;

namespace ChannelEngineTop5Orders.Core.Handlers
{
	public interface IGenericQueryHandler<in TQuery, TResult>
	{
		Task<IResponseContainerWithValue<TResult>> HandleAsync(TQuery query);
	}
}
