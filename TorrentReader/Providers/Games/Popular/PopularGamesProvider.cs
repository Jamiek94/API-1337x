using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Games.Popular
{
    public class PopularGamesProvider : TorrentProvider, IPopularGamesProvider
    {
        public PopularGamesProvider(IOverviewTransformer overviewTransformer) : base(overviewTransformer)
        {
        }

        public Task<IReadOnlyList<SearchResultItem>> GetAsync(TorrentPopularityRange movieRangeType)
        {
            return Get(GetPopularPath(movieRangeType));
        }

        private string GetPopularPath(TorrentPopularityRange popularRangeType)
        {
            if (popularRangeType == TorrentPopularityRange.Today)
            {
                return "popular-games";
            }

            return "popular-games-week";
        }
    }
}
