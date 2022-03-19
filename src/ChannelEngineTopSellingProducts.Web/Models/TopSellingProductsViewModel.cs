namespace ChannelEngineTopSellingProducts.Web.Models;

public sealed class TopSellingProductsViewModel
{
	public IReadOnlyCollection<TopSellingProductViewModel> TopSellingProducts { get; init; } = Array.Empty<TopSellingProductViewModel>();
}