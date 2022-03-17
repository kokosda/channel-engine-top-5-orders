using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineTop5Orders.Application.DependencyInjection
{
	public static class DependencyRegistrar
	{
		public static IServiceCollection AddApplicationLevelServices(this IServiceCollection serviceCollection)
		{
			return serviceCollection;
		}
	}
}
