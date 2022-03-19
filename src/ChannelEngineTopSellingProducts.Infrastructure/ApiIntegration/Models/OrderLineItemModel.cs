namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;

public sealed class OrderLineItemModel
{
	public string Description { get; init; } = string.Empty;
	public string Gtin { get; init; } = string.Empty;
	public string MerchantProductNo { get; init; } = string.Empty;
	public string ChannelProductNo { get; init; } = string.Empty;
	public int Quantity { get; init; }
}