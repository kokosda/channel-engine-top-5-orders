namespace ChannelEngineTopSellingProducts.Infrastructure.DataAccess;

public sealed class InMemoryDatabase : IInMemoryDatabase
{
	private readonly Dictionary<string,object> _storage;

	public InMemoryDatabase()
	{
		_storage = new Dictionary<string, object>();
	}

	public void PersistObject<T>(T @object, string key) where T: class
	{
		var combinedKey = GetCombinedKey<T>(key);
		_storage[combinedKey] = @object;
	}

	public T? GetPersistedObject<T>(string key) where T : class
	{
		var combinedKey = GetCombinedKey<T>(key);

		if (!_storage.TryGetValue(combinedKey, out var value))
			return null;

		var result = value as T;
		return result;
	}

	private static string GetCombinedKey<T>(string key) where T: class
	{
		var result = $"{typeof(T).FullName}_{key}" ?? throw new NullReferenceException($"Type's {typeof(T)} FullName is not defined.");
		return result;
	}
}