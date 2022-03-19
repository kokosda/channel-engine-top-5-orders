namespace ChannelEngineTopSellingProducts.Web.Models;

public sealed class TopSellingProductViewModel
{
	public string Name { get; init; } = string.Empty;
	public string Gtin { get; init; } = string.Empty;
	public int TotalQuantity { get; init; }
}