using System.Net.Http.Json;
using System.Text;
using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration;

public sealed class ChannelEngineRestApiClient : IChannelEngineApiClient
{
	private readonly string _apiKey;
	private readonly HttpClient _httpClient;

	public ChannelEngineRestApiClient(HttpClient httpClient, IConfiguration configuration)
	{
		if (configuration == null)
			throw new ArgumentNullException(nameof(configuration));

		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		_apiKey = configuration["ChannelEngineRestApiClient.ApiKey"] ?? throw new NullReferenceException("ChannelEngineRestApiClient.ApiKey is not defined.");
	}

	public async Task<IReadOnlyCollection<OrderModel>> GetOrdersByStatus(string status)
	{
		if (status == null)
			throw new ArgumentNullException(nameof(status));

		var requestUri = $"apikey={_apiKey}&statuses={status}";
		var orderResponse = await _httpClient.GetFromJsonAsync<OrderResponseModel>(requestUri);

		if (orderResponse is null)
			return Array.Empty<OrderModel>();

		var result = orderResponse.Content;
		return result;
	}

	public async Task<UpdateProductResponseModel?> UpdateProduct(ProductModel productModel)
	{
		var pathDoc = new JsonPatchDocument<ProductModel>()
			.Replace(p => p.Stock, productModel.Stock);
		var content = new StringContent(JsonConvert.SerializeObject(pathDoc), Encoding.UTF8, "application/json-patch+json");
		var requestUri = $"products/{productModel.MerchantProductNo}/?apikey={_apiKey}";
		var response = await _httpClient.PatchAsync(requestUri, content);
		var responseString = await response.Content.ReadAsStringAsync();
		var result = JsonConvert.DeserializeObject<UpdateProductResponseModel>(responseString);
		return result;
	}
}