using ChannelEngineTopSellingProducts.Application.Products;

namespace ChannelEngineTopSellingProducts.Web.Models.Extensions;

public static class TopSellingProductsViewModelExtensions
{
	public static TopSellingProductsViewModel ToViewModel(this TopSellingProductsDto topSellingProductsDto)
	{
		if (topSellingProductsDto == null)
			throw new ArgumentNullException(nameof(topSellingProductsDto));

		var result = new TopSellingProductsViewModel
		{
			TopSellingProducts = topSellingProductsDto.TopSellingProducts.Select(tsp => tsp.ToViewModel()).ToArray()
		};
		return result;
	}
}