using ChannelEngineTopSellingProducts.Domain.Products;

namespace ChannelEngineTopSellingProducts.Infrastructure.DataAccess.Products;

public sealed class ProductsInMemoryRepository : IProductsRepository
{
	private readonly IInMemoryDatabase _inMemoryDatabase;

	public ProductsInMemoryRepository(IInMemoryDatabase inMemoryDatabase)
	{
		_inMemoryDatabase = inMemoryDatabase ?? throw new ArgumentNullException(nameof(inMemoryDatabase));
	}

	public Task<IReadOnlyCollection<TopSellingProduct>?> GetTopSellingByQuantity(int quantity)
	{
		var result = _inMemoryDatabase.GetPersistedObject<IReadOnlyCollection<TopSellingProduct>>($"TopSellingProducts_{quantity}");
		return Task.FromResult(result);
	}

	public Task SaveTopSellingProducts(IReadOnlyCollection<TopSellingProduct> topSellingProducts, int expectedMaxQuantity)
	{
		_inMemoryDatabase.PersistObject(topSellingProducts, $"TopSellingProducts_{expectedMaxQuantity}");
		return Task.CompletedTask;
	}
}