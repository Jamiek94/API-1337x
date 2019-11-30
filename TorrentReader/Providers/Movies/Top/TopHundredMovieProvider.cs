using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Movies.Top
{
    public class TopHundredMovieProvider : TorrentProvider, ITopHundredMovieProvider
    {
        public TopHundredMovieProvider(IOverviewTransformer overviewTransformer) : base(overviewTransformer)
        {
        }

        public Task<IReadOnlyList<SearchResultItem>> GetAsync()
        {
            return Get("top-100-movies");
        }
    }
}
