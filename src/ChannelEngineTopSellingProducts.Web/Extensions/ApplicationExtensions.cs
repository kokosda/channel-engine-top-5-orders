using ChannelEngineTopSellingProducts.Application.StartUp;

namespace ChannelEngineTopSellingProducts.Web.Extensions;

public static class ApplicationExtensions
{
	public static IApplicationBuilder UseStartUpRoutine(this WebApplication app)
	{
		var startUpRoutine = app.Services.GetService<IStartUpRoutine>();
		startUpRoutine?.Run().Wait();
		return app;
	}
}