using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Games.Top
{
    public class TopHundredGamesProvider : TorrentProvider, ITopHundredGamesProvider
    {
        public TopHundredGamesProvider(IOverviewTransformer overviewTransformer) : base(overviewTransformer)
        {
        }

        public Task<IReadOnlyList<SearchResultItem>> GetAsync()
        {
            return Get("top-100-games");
        }
    }
}
