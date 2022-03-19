namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;

public sealed class ProductModel
{
	public string MerchantProductNo { get; init; } = string.Empty;
	public int Stock { get; init; }
}