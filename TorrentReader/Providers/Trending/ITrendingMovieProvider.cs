using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Trending
{
    public interface ITrendingTorrentsProvider
    {
        Task<IReadOnlyList<SearchResultItem>> GetAsync(TorrentPopularityRange popularityRange);
    }
}