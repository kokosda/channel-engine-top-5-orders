namespace ChannelEngineTop5Orders.Core.Core.Interfaces
{
	public interface IResponseContainerWithValue<T> : IResponseContainer
	{
		T Value { get; }
		
		void SetSuccessValue(T value);
	}
}
