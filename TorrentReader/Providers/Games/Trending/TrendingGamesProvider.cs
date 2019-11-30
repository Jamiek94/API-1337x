using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Games.Trending
{
    public class TrendingGamesProvider : TorrentProvider, ITrendingGamesProvider
    {
        public TrendingGamesProvider(IOverviewTransformer overviewTransformer) : base(overviewTransformer)
        {
        }

        public Task<IReadOnlyList<SearchResultItem>> GetAsync(TorrentPopularityRange torrentPopularityRange)
        {
            return Get(GetMoviesRelativeUrl(torrentPopularityRange));
        }

        private string GetMoviesRelativeUrl(TorrentPopularityRange movieRangeType)
        {
            if (movieRangeType == TorrentPopularityRange.Today)
            {
                return "trending/d/games/";
            }

            return "trending/w/games/";
        }
    }
}
