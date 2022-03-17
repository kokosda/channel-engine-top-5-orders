using System;
using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Handlers;
using ChannelEngineTop5Orders.Core.Interfaces;

namespace ChannelEngineTop5Orders.Application.Handlers
{
	public abstract class GenericCommandHandlerBase<TCommand, TResult> : IGenericCommandHandler<TCommand, TResult>
	{
		public async Task<IResponseContainerWithValue<TResult>> HandleAsync(TCommand command)
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			return await GetResultAsync(command);
		}

		protected abstract Task<IResponseContainerWithValue<TResult>> GetResultAsync(TCommand command);
	}
}
