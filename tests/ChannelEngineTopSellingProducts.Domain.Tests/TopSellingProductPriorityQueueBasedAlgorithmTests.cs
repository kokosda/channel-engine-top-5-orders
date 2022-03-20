using System.IO;
using System.Linq;
using ChannelEngineTopSellingProducts.Domain.Products;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ChannelEngineTopSellingProducts.Domain.Tests;

[TestFixture]
public sealed class TopSellingProductPriorityQueueBasedAlgorithmTests
{
	private TopSellingProductPriorityQueueBasedAlgorithm _algorithm;

	[SetUp]
	public void SetUp()
	{
		_algorithm = new TopSellingProductPriorityQueueBasedAlgorithm();
	}

	[TestCase(4)]
	public void GetTopSellingProducts_WhenOnlyUniqueProductsAppearInTheList_ReturnsExpectedTopCount(int expectedTopCount)
	{
		// Arrange
		var products = GetProductsByTestName(TestContext.CurrentContext.Test.Name);

		// Act
		var result = _algorithm.GetTopSellingProducts(products, expectedTopCount);

		// Assert
		Assert.IsNotNull(result);
		Assert.AreEqual(expectedTopCount, result.Count);
		Assert.AreEqual(8, result.ElementAt(0).TotalQuantity);
		Assert.AreEqual(7, result.ElementAt(1).TotalQuantity);
		Assert.AreEqual(6, result.ElementAt(2).TotalQuantity);
		Assert.AreEqual(5, result.ElementAt(3).TotalQuantity);
	}

	private Product[] GetProductsByTestName(string testName)
	{
		var content = File.ReadAllText($"Resources/{nameof(TopSellingProductPriorityQueueBasedAlgorithmTests)}/{testName}.json");
		var result = JsonConvert.DeserializeObject<Product[]>(content);
		return result;
	}
}