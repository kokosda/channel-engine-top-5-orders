using ChannelEngineTopSellingProducts.Domain.Products;

namespace ChannelEngineTopSellingProducts.Infrastructure.DataAccess.Products;

public sealed class ProductsInMemoryRepository : IProductsRepository
{
	private readonly IInMemoryDatabase _inMemoryDatabase;

	public ProductsInMemoryRepository(IInMemoryDatabase inMemoryDatabase)
	{
		_inMemoryDatabase = inMemoryDatabase ?? throw new ArgumentNullException(nameof(inMemoryDatabase));
	}

	public Task<IReadOnlyCollection<TopSellingProduct>?> GetTopSellingByAmount(int amount)
	{
		var result = _inMemoryDatabase.GetPersistedObject<IReadOnlyCollection<TopSellingProduct>>($"TopSellingProducts_{amount}");
		return Task.FromResult(result);
	}

	public Task SaveTopSellingByAmount(IReadOnlyCollection<TopSellingProduct> topSellingProducts)
	{
		_inMemoryDatabase.PersistObject(topSellingProducts, $"TopSellingProducts_{topSellingProducts.Count}");
		return Task.CompletedTask;
	}
}