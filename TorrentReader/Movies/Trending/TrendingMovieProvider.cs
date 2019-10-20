using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TorrentReader.Config;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Movies.Trending
{
    public class TrendingMovieProvider : ITrendingMovieProvider
    {
        private readonly IOverviewTransformer _overviewTransformer;

        public TrendingMovieProvider(IOverviewTransformer overviewTransformer)
        {
            _overviewTransformer = overviewTransformer;
        }

        public async Task<IReadOnlyList<SearchResultItem>> GetAsync(MovieRangeType movieRangeType)
        {
            var web = new HtmlWeb();

            var trendingRelativeUrl = $"{Configuration.BaseUrl}/{GetMoviesRelativeUrl(movieRangeType)}";

            var document = await web.LoadFromWebAsync(trendingRelativeUrl).ConfigureAwait(false);

            return _overviewTransformer.Transform(document);
        }

        private string GetMoviesRelativeUrl(MovieRangeType movieRangeType)
        {
            if (movieRangeType == MovieRangeType.Today)
            {
                return "trending/d/movies/";
            }

            return "trending/w/movies/";
        }
    }
}
