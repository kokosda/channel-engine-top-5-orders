namespace ChannelEngineTopSellingProducts.Web.Models;

public sealed class TopSellingProductViewModel
{
	public string Id { get; set; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Gtin { get; init; } = string.Empty;
	public long TotalQuantity { get; init; }
}