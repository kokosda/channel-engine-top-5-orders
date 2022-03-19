using System;
using ChannelEngineTopSellingProducts.Domain.Products;

namespace ChannelEngineTopSellingProducts.Application.Products;

public static class TopSellingProductExtensions
{
	public static TopSellingProductDto ToTopSellingProductDto(this TopSellingProduct topSellingProduct)
	{
		if (topSellingProduct == null)
			throw new ArgumentNullException(nameof(topSellingProduct));

		var result = new TopSellingProductDto
		{
			Id = topSellingProduct.Id,
			Name = topSellingProduct.Name,
			Gtin = topSellingProduct.Gtin,
			TotalQuantity = topSellingProduct.TotalQuantity
		};
		return result;
	}
}