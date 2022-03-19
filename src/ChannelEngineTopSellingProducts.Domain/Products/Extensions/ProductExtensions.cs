namespace ChannelEngineTopSellingProducts.Domain.Products.Extensions;

public static class ProductExtensions
{
	public static TopSellingProduct ToTopSellingProduct(this Product product, int totalQuantity)
	{
		var result = new TopSellingProduct
		{
			Id = product.Id,
			Name = product.Name,
			MerchantProductNo = product.MerchantProductNo,
			Gtin = product.Gtin,
			TotalQuantity = totalQuantity
		};
		return result;
	}
}