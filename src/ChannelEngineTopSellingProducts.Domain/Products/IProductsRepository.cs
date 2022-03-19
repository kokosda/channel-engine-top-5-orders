namespace ChannelEngineTopSellingProducts.Domain.Products;

public interface IProductsRepository
{
	/// <summary>
	/// Returns a list of the top <param name="quantity" /> products sold.
	/// </summary>
	Task<IReadOnlyCollection<TopSellingProduct>?> GetTopSellingByQuantity(int quantity);

	Task SaveTopSellingProducts(IReadOnlyCollection<TopSellingProduct> topSellingProducts, int expectedMaxQuantity);
}