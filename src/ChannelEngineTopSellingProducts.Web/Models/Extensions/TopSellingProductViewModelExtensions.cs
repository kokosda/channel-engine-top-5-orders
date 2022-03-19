using ChannelEngineTopSellingProducts.Application.Products;

namespace ChannelEngineTopSellingProducts.Web.Models.Extensions;

public static class TopSellingProductViewModelExtensions
{
	public static TopSellingProductViewModel ToViewModel(this TopSellingProductDto topSellingProductDto)
	{
		if (topSellingProductDto == null)
			throw new ArgumentNullException(nameof(topSellingProductDto));

		var result = new TopSellingProductViewModel
		{
			Id = topSellingProductDto.Id,
			Name = topSellingProductDto.Name,
			Gtin = topSellingProductDto.Gtin,
			TotalQuantity = topSellingProductDto.TotalQuantity
		};

		return result;
	}
}