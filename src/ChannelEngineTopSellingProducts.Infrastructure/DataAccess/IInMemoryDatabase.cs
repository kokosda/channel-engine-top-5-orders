namespace ChannelEngineTopSellingProducts.Infrastructure.DataAccess;

public interface IInMemoryDatabase
{
	void PersistObject<T>(T @object, string key) where T: class;
	T? GetPersistedObject<T>(string key) where T : class;
}