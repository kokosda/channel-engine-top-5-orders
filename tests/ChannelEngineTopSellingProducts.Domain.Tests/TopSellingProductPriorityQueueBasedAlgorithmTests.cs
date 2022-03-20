using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ChannelEngineTopSellingProducts.Domain.Products;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ChannelEngineTopSellingProducts.Domain.Tests;

[TestFixture]
public sealed class TopSellingProductPriorityQueueBasedAlgorithmTests
{
	private TopSellingProductPriorityQueueBasedAlgorithm? _algorithm;

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
		var result = _algorithm?.GetTopSellingProducts(products, expectedTopCount);

		// Assert
		Assert.IsNotNull(result);
		Assert.AreEqual(expectedTopCount, result?.Count);
		Assert.AreEqual(8, result?.ElementAt(0).TotalQuantity);
		Assert.AreEqual(7, result?.ElementAt(1).TotalQuantity);
		Assert.AreEqual(6, result?.ElementAt(2).TotalQuantity);
		Assert.AreEqual(5, result?.ElementAt(3).TotalQuantity);
	}

	[TestCase(5)]
	public void GetTopSellingProducts_WhenDuplicatedProductsAppearInTheList_ReturnsExpectedTopCount(int expectedTopCount)
	{
		// Arrange
		var products = GetProductsByTestName(TestContext.CurrentContext.Test.Name);

		// Act
		var result = _algorithm?.GetTopSellingProducts(products, expectedTopCount);

		// Assert
		Assert.IsNotNull(result);
		Assert.AreEqual(expectedTopCount, result?.Count);
		Assert.AreEqual(8, result?.ElementAt(0).TotalQuantity);
		Assert.AreEqual(8, result?.ElementAt(1).TotalQuantity);
		Assert.AreEqual(7, result?.ElementAt(2).TotalQuantity);
		Assert.AreEqual(6, result?.ElementAt(3).TotalQuantity);
		Assert.AreEqual(4, result?.ElementAt(4).TotalQuantity);
	}

	[TestCase(5, 3, new [] { 7, 6, 3 })]
	[TestCase(5, 0, new int[0])]
	[TestCase(5, 1, new [] { 3 })]
	public void GetTopSellingProducts_WhenTopCountGreaterThanProductsCount_ReturnsTopCount(int maxTopCount, int expectedTopCount, int[] expectedQuantities)
	{
		// Arrange
		var products = GetProductsByTestName(TestContext.CurrentContext.Test.Name);

		// Act
		var result = _algorithm?.GetTopSellingProducts(products, maxTopCount);

		// Assert
		Assert.IsNotNull(result);
		Assert.AreEqual(expectedTopCount, result?.Count);

		for (var i = 0; i < expectedTopCount; i++)
		{
			Assert.AreEqual(expectedQuantities[i], result?.ElementAt(i).TotalQuantity);
		}
	}

	[TestCase(10_000_000, 5, 60D)]
	[TestCase(1_000_000, 5, 6D)]
	[TestCase(100_000, 5, 1D)]
	public void GetTopSellingProducts_WhenProductCountIsMillionsInCount_PerformanceIsExpected(int elementsCount, int expectedTopCount, double expectedMaxExecutionTimeInSeconds)
	{
		// Arrange
		var productsList = new List<Product>();

		for (int i = 0; i < elementsCount; i++)
		{
			var randomString = Random.Shared.Next(1, 10_000_000).ToString();
			var product = new Product
			{
				Id = randomString,
				Gtin = randomString,
				Name = randomString,
				Quantity = Random.Shared.Next(1, 1000),
				MerchantProductNo = randomString
			};
			productsList.Add(product);
		}

		// Act
		var sw = Stopwatch.StartNew();
		var result = _algorithm?.GetTopSellingProducts(productsList, expectedTopCount);
		sw.Stop();

		// Assert
		Assert.IsNotNull(result);
		Assert.AreEqual(expectedTopCount, result?.Count);
		Assert.That(expectedMaxExecutionTimeInSeconds, Is.GreaterThanOrEqualTo(sw.Elapsed.TotalSeconds));
	}

	private Product[] GetProductsByTestName(string testName)
	{
		var content = File.ReadAllText($"Resources/{nameof(TopSellingProductPriorityQueueBasedAlgorithmTests)}/{testName}.json");
		var result = JsonConvert.DeserializeObject<Product[]>(content);
		return result;
	}
}