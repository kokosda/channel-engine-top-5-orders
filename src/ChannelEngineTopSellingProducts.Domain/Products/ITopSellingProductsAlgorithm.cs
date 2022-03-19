namespace ChannelEngineTopSellingProducts.Domain.Products;

public interface ITopSellingProductsAlgorithm
{
	IReadOnlyCollection<TopSellingProduct> GetTopSellingProducts(IReadOnlyCollection<Product> products, int topCount);
}