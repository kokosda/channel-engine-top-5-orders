using System;
using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Handlers;
using ChannelEngineTop5Orders.Core.Interfaces;

namespace ChannelEngineTop5Orders.Application.Handlers
{
	public abstract class CommandHandlerBase<T> : ICommandHandler<T>
	{
		public async Task<IResponseContainer> HandleAsync(T command)
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var result = await GetResultAsync(command);
			return result;
		}

		protected abstract Task<IResponseContainer> GetResultAsync(T command);
	}
}
