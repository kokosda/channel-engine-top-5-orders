﻿using System;
using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Handlers;
using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Application.Handlers
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
