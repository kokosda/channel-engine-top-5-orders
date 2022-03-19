namespace ChannelEngineTopSellingProducts.Infrastructure.ApiIntegration.Models;

public sealed class OrderModel
{
	public OrderLineItemModel[] Lines { get; init; } = Array.Empty<OrderLineItemModel>();
}