using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Core.Handlers
{
	public interface IGenericCommandHandler<in TCommand, TResult>
	{
		Task<IResponseContainerWithValue<TResult>> HandleAsync(TCommand command);
	}
}
