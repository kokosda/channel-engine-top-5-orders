using System;
using System.Collections.Generic;

namespace ChannelEngineTop5Orders.Application.Products;

public sealed class TopSellingProductsDto
{
	public IReadOnlyCollection<TopSellingProductDto> TopSellingProducts { get; init; } = Array.Empty<TopSellingProductDto>();
}