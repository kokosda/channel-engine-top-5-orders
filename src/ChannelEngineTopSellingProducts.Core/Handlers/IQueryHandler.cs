using System.Threading.Tasks;
using ChannelEngineTopSellingProducts.Core.Interfaces;

namespace ChannelEngineTopSellingProducts.Core.Handlers
{
    public interface IQueryHandler<in T>
    {
        Task<IResponseContainer> HandleAsync(T query);
    }
}