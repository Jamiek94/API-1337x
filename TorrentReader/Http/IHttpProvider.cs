using System.Collections.Generic;
using System.Threading.Tasks;

namespace TorrentReader.Http
{
    public interface IHttpProvider
    {
        Task<IReadOnlyList<TEntity>> GetAsync<TEntity>(string relativeUrl) where TEntity : class;
    }
}