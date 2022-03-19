using ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;

namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration;

public interface IChannelEngineApiClient
{
	Task<IReadOnlyCollection<OrderModel>> GetOrdersByStatus(string status);
	Task<UpdateProductResponseModel?> UpdateProduct(ProductModel productModel);
}