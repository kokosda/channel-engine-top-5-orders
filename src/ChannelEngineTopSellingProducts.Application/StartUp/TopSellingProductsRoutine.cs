using System;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Domain.Products;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ChannelEngineTopSellingProducts.Application.StartUp;

public sealed class TopSellingProductsRoutine : IStartUpRoutine
{
	private readonly IChannelEngineApiClient _channelEngineApiClient;
	private readonly IProductsRepository _productsRepository;
	private readonly ILogger<TopSellingProductsRoutine> _logger;

	public TopSellingProductsRoutine(IChannelEngineApiClient channelEngineApiClient, IProductsRepository productsRepository, ILogger<TopSellingProductsRoutine> logger)
	{
		_channelEngineApiClient = channelEngineApiClient ?? throw new ArgumentNullException(nameof(channelEngineApiClient));
		_productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
		_logger = logger;
	}

	public async Task Run()
	{
		var orders = await _channelEngineApiClient.GetOrdersByStatus(OrderStatuses.InProgress);
		var topSellingProducts = orders.SelectMany(o => o.Lines)
			.Take(5)
			.Select(item => new TopSellingProduct
			{
				Id = item.ChannelProductNo,
				Name = item.Description,
				Gtin = item.Gtin,
				MerchantProductNo = item.MerchantProductNo,
				TotalQuantity = item.Quantity
			})
			.ToArray();

		_logger.LogInformation($"Top selling products collection was obtained: {JsonConvert.SerializeObject(topSellingProducts)}");

		await _productsRepository.SaveTopSellingByAmount(topSellingProducts);

		var productIndexToSave = Random.Shared.Next(0, topSellingProducts.Length);
		var topSellingProduct = topSellingProducts[productIndexToSave];
		var productModel = new ProductModel
		{
			MerchantProductNo = topSellingProduct.MerchantProductNo,
			Stock = 25
		};

		var updateProductResponse = await _channelEngineApiClient.UpdateProduct(productModel);
		_logger.LogInformation($"Update product response: {JsonConvert.SerializeObject(updateProductResponse)}");
	}
}