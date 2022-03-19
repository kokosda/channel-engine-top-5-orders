using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Domain.Products;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ChannelEngineTopSellingProducts.Application.StartUp;

public sealed class TopSellingProductsRoutine : IStartUpRoutine
{
	private readonly IChannelEngineApiClient _channelEngineApiClient;
	private readonly IProductsRepository _productsRepository;
	private readonly ILogger<TopSellingProductsRoutine> _logger;
	private readonly ITopSellingProductsAlgorithm _topSellingProductsAlgorithm;
	private readonly IConfiguration _configuration;

	public TopSellingProductsRoutine(IChannelEngineApiClient channelEngineApiClient, IProductsRepository productsRepository, ILogger<TopSellingProductsRoutine> logger, ITopSellingProductsAlgorithm topSellingProductsAlgorithm, IConfiguration configuration)
	{
		_channelEngineApiClient = channelEngineApiClient ?? throw new ArgumentNullException(nameof(channelEngineApiClient));
		_productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_topSellingProductsAlgorithm = topSellingProductsAlgorithm ?? throw new ArgumentNullException(nameof(topSellingProductsAlgorithm));
		_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
	}

	public async Task Run()
	{
		var orders = await _channelEngineApiClient.GetOrdersByStatus(OrderStatuses.InProgress);
		var products = orders.SelectMany(o => o.Lines)
			.Select(item => item.ToProduct())
			.ToImmutableList();
		var topCount = int.Parse(_configuration["TopSellingProductCount"]);
		var topSellingProducts = _topSellingProductsAlgorithm.GetTopSellingProducts(products, topCount: topCount);

		_logger.LogInformation($"Top selling products collection was obtained: {JsonConvert.SerializeObject(topSellingProducts)}");

		await _productsRepository.SaveTopSellingProducts(topSellingProducts, topCount);

		var productIndexToSave = Random.Shared.Next(0, topSellingProducts.Count);
		var topSellingProduct = topSellingProducts.ElementAt(productIndexToSave);
		var productModel = new ProductModel
		{
			MerchantProductNo = topSellingProduct.MerchantProductNo,
			Stock = 25
		};

		var updateProductResponse = await _channelEngineApiClient.UpdateProduct(productModel);
		_logger.LogInformation($"Update product response: {JsonConvert.SerializeObject(updateProductResponse)}");
	}
}