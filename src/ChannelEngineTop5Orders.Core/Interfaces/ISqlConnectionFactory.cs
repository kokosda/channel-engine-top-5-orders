using System.Data;

namespace ChannelEngineTop5Orders.Core.Interfaces
{
	public interface ISqlConnectionFactory
	{
		IDbConnection GetOpenConnection();
	}
}
