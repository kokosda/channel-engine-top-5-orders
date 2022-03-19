using ChannelEngineTopSellingProducts.Application.Products;

namespace ChannelEngineTopSellingProducts.Web.Models.Extensions;

public static class TopSellingProductViewModelExtensions
{
	public static TopSellingProductViewModel ToViewModel(this TopSellingProductDto topSellingProductViewModel)
	{
		if (topSellingProductViewModel == null)
			throw new ArgumentNullException(nameof(topSellingProductViewModel));

		var result = new TopSellingProductViewModel
		{
			Name = topSellingProductViewModel.Name,
			Gtin = topSellingProductViewModel.Gtin,
			TotalQuantity = topSellingProductViewModel.TotalQuantity
		};

		return result;
	}
}