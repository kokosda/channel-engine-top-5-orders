using ChannelEngineTopSellingProducts.Core.Handlers;
using ChannelEngineTopSellingProducts.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineTopSellingProducts.Application.DependencyInjection
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
