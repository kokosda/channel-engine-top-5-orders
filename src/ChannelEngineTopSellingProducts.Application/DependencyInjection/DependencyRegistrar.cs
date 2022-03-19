using ChannelEngineTopSellingProducts.Core.Handlers;
using ChannelEngineTopSellingProducts.Application.Products;
using ChannelEngineTopSellingProducts.Application.StartUp;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineTopSellingProducts.Application.DependencyInjection
{
	public static class DependencyRegistrar
	{
		public static IServiceCollection AddApplicationLevelServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IGenericQueryHandler<TopSellingProductsQuery, TopSellingProductsDto>, TopSellingProductQueryHandler>();
			serviceCollection.AddSingleton<IStartUpRoutine, TopSellingProductsRoutine>();
			return serviceCollection;
		}
	}
}
