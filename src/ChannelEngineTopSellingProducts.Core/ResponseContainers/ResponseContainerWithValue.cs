using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Core.ResponseContainers
{
	public sealed class ResponseContainerWithValue<T> : ResponseContainer, IResponseContainerWithValue<T> where T: new()
	{
		public T Value { get; private set; } = new();

		public void SetSuccessValue(T value)
		{
			Value = value;
			IsSuccess = true;
		}

		public new IResponseContainerWithValue<T> JoinWith(IResponseContainer anotherResponseContainer)
		{
			base.JoinWith(anotherResponseContainer);
			return this;
		}
	}
}
