using System;
using System.Linq;
using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Handlers;
using ChannelEngineTopSellingProducts.Core.Interfaces;
using ChannelEngineTopSellingProducts.Core.ResponseContainers;
using ChannelEngineTopSellingProducts.Domain.Products;

namespace ChannelEngineTopSellingProducts.Application.Products;

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
		var topSellingProductsList = await _productsRepository.GetTopSellingByQuantity(query.AmountOfTopProducts) ?? Array.Empty<TopSellingProduct>();
		var topSellingProducts = new TopSellingProductsDto
		{
			TopSellingProducts = topSellingProductsList.Select(tsp => tsp.ToTopSellingProductDto()).ToArray()
		};

		result.SetSuccessValue(topSellingProducts);
		return result;
	}
}