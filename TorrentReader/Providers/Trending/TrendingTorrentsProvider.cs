using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Trending
{
    public class TrendingTorrentsProvider : TorrentProvider, ITrendingTorrentsProvider
    {
        public TrendingTorrentsProvider(IOverviewTransformer overviewTransformer) : base(overviewTransformer)
        {
        }

        public Task<IReadOnlyList<SearchResultItem>> GetAsync(TorrentPopularityRange popularityRange)
        {
            return Get(GetTrendingRelativeUrl(popularityRange));
        }

        private string GetTrendingRelativeUrl(TorrentPopularityRange movieRangeType)
        {
            if (movieRangeType == TorrentPopularityRange.Today)
            {
                return "trending-week";
            }

            return "trending";
        }
    }
}
