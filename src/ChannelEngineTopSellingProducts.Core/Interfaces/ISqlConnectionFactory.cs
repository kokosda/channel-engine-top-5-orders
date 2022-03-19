using System.Data;

namespace ChannelEngineTopSellingProducts.Core.Interfaces
{
	public interface ISqlConnectionFactory
	{
		IDbConnection GetOpenConnection();
	}
}
