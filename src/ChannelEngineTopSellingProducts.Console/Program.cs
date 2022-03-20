// See https://aka.ms/new-console-template for more information

using System.Text;
using ChannelEngineTopSellingProducts.Application.DependencyInjection;
using ChannelEngineTopSellingProducts.Application.Products;
using ChannelEngineTopSellingProducts.Application.StartUp;
using ChannelEngineTopSellingProducts.Core.Handlers;
using ChannelEngineTopSellingProducts.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
		services
			.AddLogging(loggingBuilder => loggingBuilder.ClearProviders().AddConsole())
			.AddInfrastructureLevelServices(context.Configuration)
			.AddApplicationLevelServices()
		)
	.Build();

var logger = host.Services.GetService<ILoggerFactory>()?.CreateLogger<Program>();

logger?.LogInformation("Starting application.");

var startupRoutine = host.Services.GetService<IStartUpRoutine>() ?? throw new NullReferenceException("Startup routine is not defined.");

await startupRoutine.Run();

var configuration = host.Services.GetService<IConfiguration>() ?? throw new NullReferenceException("Configuration is not defined.");
var topSellingProductCount = int.Parse(configuration["TopSellingProductCount"]);
var topSellingProductsQuery = new TopSellingProductsQuery { AmountOfTopProducts = topSellingProductCount };
var topSellingProductsQueryHandler = host.Services.GetService<IGenericQueryHandler<TopSellingProductsQuery, TopSellingProductsDto>>() ?? throw new NullReferenceException("TopSellingProduct query handler is not defined.");

var responseContainer = await topSellingProductsQueryHandler.HandleAsync(topSellingProductsQuery);

if (!responseContainer.IsSuccess)
	logger?.LogError(responseContainer.Messages);
else
{
	var logMessage = new StringBuilder();
	foreach (var topSellingProductDto in responseContainer.Value.TopSellingProducts)
	{
		logMessage.Append($"{topSellingProductDto.Id} | {topSellingProductDto.Name} | {topSellingProductDto.Gtin} |  {topSellingProductDto.TotalQuantity}");
		logMessage.AppendLine();
	}

	logger?.LogInformation(logMessage.ToString());
}

await host.RunAsync();
