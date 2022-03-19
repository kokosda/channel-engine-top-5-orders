using System;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Handlers;
using ChannelEngineTop5Orders.Core.Interfaces;
using ChannelEngineTop5Orders.Core.ResponseContainers;
using ChannelEngineTop5Orders.Domain.Products;

namespace ChannelEngineTop5Orders.Application.Products;

public class TopSellingProductQueryHandler : IGenericQueryHandler<TopSellingProductsQuery, TopSellingProductsDto>
{
	private readonly IProductsRepository _productsRepository;

	public TopSellingProductQueryHandler(IProductsRepository productsRepository)
	{
		_productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
	}

	public async Task<IResponseContainerWithValue<TopSellingProductsDto>> HandleAsync(TopSellingProductsQuery query)
	{
		var result = new ResponseContainerWithValue<TopSellingProductsDto>();
		var topSellingProductsList = await _productsRepository.GetTopSellingByAmount(query.AmountOfTopProducts);
		var topSellingProducts = new TopSellingProductsDto
		{
			TopSellingProducts = topSellingProductsList.Select(tsp => tsp.ToTopSellingProductDto()).ToArray()
		};

		result.SetSuccessValue(topSellingProducts);
		return result;
	}
}