using System.Data;

namespace ChannelEngineTop5Orders.Core.Core.Interfaces
{
	public interface ISqlConnectionFactory
	{
		IDbConnection GetOpenConnection();
	}
}
