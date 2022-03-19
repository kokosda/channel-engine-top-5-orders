using ChannelEngineTopSellingProducts.Domain.Products;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration;
using ChannelEngineTopSellingProducts.Infrastructure.DataAccess;
using ChannelEngineTopSellingProducts.Infrastructure.DataAccess.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineTopSellingProducts.Infrastructure.DependencyInjection
{
	public static class DependencyRegistrar
	{
		public static IServiceCollection AddInfrastructureLevelServices(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			serviceCollection.AddSingleton<IInMemoryDatabase, InMemoryDatabase>();
			serviceCollection.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
			serviceCollection.AddSingleton<ITopSellingProductsAlgorithm, TopSellingProductPriorityQueueBasedAlgorithm>();

			AddChannelEngineRestApiClient(serviceCollection, configuration);
			return serviceCollection;
		}

		private static void AddChannelEngineRestApiClient(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			var baseUrl = configuration["ChannelEngineRestApiClient.BaseUrl"] ?? throw new NullReferenceException("ChannelEngineRestApiClient.BaseUrl is not defined.");

			serviceCollection.AddHttpClient<IChannelEngineApiClient, ChannelEngineRestApiClient>(client =>
			{
				client.BaseAddress = new Uri(baseUrl);
			});
		}
	}
}
