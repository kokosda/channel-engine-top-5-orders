using ChannelEngineTopSellingProducts.Core.Domain;

namespace ChannelEngineTopSellingProducts.Domain.Products;

public sealed class TopSellingProduct : EntityBase<int>
{
	public string Name { get; init; } = string.Empty;
	public string Gtin { get; init; } = string.Empty;
	public int TotalQuantity { get; init; }
}