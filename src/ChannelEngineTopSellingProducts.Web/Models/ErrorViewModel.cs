namespace ChannelEngineTopSellingProducts.Web.Models;

public sealed class ErrorViewModel
{
	public string? RequestId { get; init; } = string.Empty;
	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	public string Message { get; init; } = string.Empty;
}