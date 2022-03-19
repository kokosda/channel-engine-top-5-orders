namespace ChannelEngineTopSellingProducts.Domain.Products;

public sealed class TopSellingProduct
{
	public string Id { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string MerchantProductNo { get; init; } = string.Empty;
	public string Gtin { get; init; } = string.Empty;
	public int TotalQuantity { get; init; }
}