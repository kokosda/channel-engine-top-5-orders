namespace ChannelEngineTopSellingProducts.Application.Products;

public sealed class TopSellingProductDto
{
	public string Id { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Gtin { get; init; } = string.Empty;
	public long TotalQuantity { get; init; }
}