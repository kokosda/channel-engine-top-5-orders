using System.Threading.Tasks;
using ChannelEngineTop5Orders.Core.Core.Interfaces;

namespace ChannelEngineTop5Orders.Core.Core.Handlers
{
    public interface IQueryHandler<in T>
    {
        Task<IResponseContainer> HandleAsync(T query);
    }
}