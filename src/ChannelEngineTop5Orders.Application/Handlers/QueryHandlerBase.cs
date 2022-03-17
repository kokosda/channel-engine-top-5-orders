using System;
using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Handlers;
using ChannelEngineTop5Orders.Core.Interfaces;

namespace ChannelEngineTop5Orders.Application.Handlers
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
