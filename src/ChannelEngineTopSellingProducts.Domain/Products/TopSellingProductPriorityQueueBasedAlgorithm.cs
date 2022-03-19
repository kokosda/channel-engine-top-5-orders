using System.Collections.Immutable;
using ChannelEngineTopSellingProducts.Domain.Products.Extensions;

namespace ChannelEngineTopSellingProducts.Domain.Products;

public sealed class TopSellingProductPriorityQueueBasedAlgorithm : ITopSellingProductsAlgorithm
{
	public IReadOnlyCollection<TopSellingProduct> GetTopSellingProducts(IReadOnlyCollection<Product> products, int topCount)
	{
		var priorityQueue = new PriorityQueue<TopSellingProduct, int>();
		var topSellingProductCandidates = products.GroupBy(p => p.Id, p => p)
			.ToImmutableDictionary(g => g.Key, GroupToTopSellingProduct);

		foreach (var (_, topSellingProduct) in topSellingProductCandidates.Take(topCount))
		{
			priorityQueue.Enqueue(topSellingProduct, topSellingProduct.TotalQuantity);
		}

		foreach (var (_, topSellingProduct) in topSellingProductCandidates.Skip(topCount))
		{
			priorityQueue.EnqueueDequeue(topSellingProduct, topSellingProduct.TotalQuantity);
		}

		var stack = new Stack<TopSellingProduct>();
		var priorityQueueEntriesCount = priorityQueue.Count;

		for (var i = 0; i < priorityQueueEntriesCount; i++)
		{
			var element = priorityQueue.Dequeue();
			stack.Push(element);
		}

		var result = stack.ToImmutableList();
		return result;
	}

	private static TopSellingProduct GroupToTopSellingProduct(IGrouping<string, Product> grouping)
	{
		var product = grouping.First();
		var totalQuantity = grouping.Sum(p => p.Quantity);
		var result = product.ToTopSellingProduct(totalQuantity);
		return result;
	}
}