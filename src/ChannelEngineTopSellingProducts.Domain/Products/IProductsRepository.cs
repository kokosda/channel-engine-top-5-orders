namespace ChannelEngineTopSellingProducts.Domain.Products;

public interface IProductsRepository
{
	/// <summary>
	/// Returns a list of the top <param name="amount" /> products sold.
	/// </summary>
	Task<IReadOnlyCollection<TopSellingProduct>> GetTopSellingByAmount(int amount);
}