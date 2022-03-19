using ChannelEngineTop5Orders.Application.Products;
using ChannelEngineTop5Orders.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineTop5Orders.Application.DependencyInjection
{
	public static class DependencyRegistrar
	{
		public static IServiceCollection AddApplicationLevelServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IGenericQueryHandler<TopSellingProductsQuery, TopSellingProductsDto>, TopSellingProductQueryHandler>();
			return serviceCollection;
		}
	}
}
