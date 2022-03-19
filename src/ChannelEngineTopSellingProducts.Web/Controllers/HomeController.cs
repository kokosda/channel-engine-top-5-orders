using System.Diagnostics;
using ChannelEngineTopSellingProducts.Application.Products;
using ChannelEngineTopSellingProducts.Core.Handlers;
using Microsoft.AspNetCore.Mvc;
using ChannelEngineTopSellingProducts.Web.Models;
using ChannelEngineTopSellingProducts.Web.Models.Extensions;

namespace ChannelEngineTopSellingProducts.Web.Controllers;

public class HomeController : Controller
{
	private readonly IGenericQueryHandler<TopSellingProductsQuery, TopSellingProductsDto> _topSellingProductsQueryHandler;

	public HomeController(IGenericQueryHandler<TopSellingProductsQuery, TopSellingProductsDto> topSellingProductsQueryHandler)
	{
		_topSellingProductsQueryHandler = topSellingProductsQueryHandler ?? throw new ArgumentNullException(nameof(topSellingProductsQueryHandler));
	}

	public async Task<IActionResult> Index()
	{
		var query = new TopSellingProductsQuery { AmountOfTopProducts = 5 };
		var responseContainer = await _topSellingProductsQueryHandler.HandleAsync(query);

		if (!responseContainer.IsSuccess)
			return Error(responseContainer.Messages);

		var viewModel = responseContainer.Value.ToViewModel();
		return View(viewModel);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error(string? message = null)
	{
		var errorViewModel = GetErrorViewModel(message);
		return View("Error", errorViewModel);
	}

	private ErrorViewModel GetErrorViewModel(string? message)
	{
		var result = new ErrorViewModel
		{
			RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
			Message = message ?? string.Empty
		};
		return result;
	}
}