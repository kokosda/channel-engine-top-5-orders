using ChannelEngineTopSellingProducts.Domain.Products;

namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models.Extensions;

public static class OrderLineItemModelExtensions
{
	public static Product ToProduct(this OrderLineItemModel orderLineItem)
	{
		var result = new Product
		{
			Id = orderLineItem.MerchantProductNo,
			Name = orderLineItem.Description,
			Gtin = orderLineItem.Gtin,
			Quantity = orderLineItem.Quantity,
			MerchantProductNo = orderLineItem.MerchantProductNo
		};
		return result;
	}
}