using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Interfaces;

namespace ChannelEngineTop5Orders.Core.Handlers
{
    public interface IQueryHandler<in T>
    {
        Task<IResponseContainer> HandleAsync(T query);
    }
}