using System;
using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Handlers;
using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Application.Handlers
{
	public abstract class QueryHandlerBase<T> : IQueryHandler<T>
	{
		public async Task<IResponseContainer> HandleAsync(T query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var result = await GetResultAsync(query);
			return result;
		}

		protected abstract Task<IResponseContainer> GetResultAsync(T command);
	}
}
