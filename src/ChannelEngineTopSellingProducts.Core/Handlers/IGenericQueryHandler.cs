using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Core.Handlers
{
	public interface IGenericQueryHandler<in TQuery, TResult>
	{
		Task<IResponseContainerWithValue<TResult>> HandleAsync(TQuery query);
	}
}
