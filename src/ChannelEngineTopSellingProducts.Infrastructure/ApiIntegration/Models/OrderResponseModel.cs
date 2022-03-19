namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;

public sealed class OrderResponseModel
{
	public OrderModel[] Content { get; init; } = Array.Empty<OrderModel>();
}