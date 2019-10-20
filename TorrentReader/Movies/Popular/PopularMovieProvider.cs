using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TorrentReader.Config;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Movies.Popular
{
    public class PopularMovieProvider : IPopularMovieProvider
    {
        private readonly IOverviewTransformer _overviewTransformer;

        public PopularMovieProvider(IOverviewTransformer overviewTransformer)
        {
            _overviewTransformer = overviewTransformer;
        }

        public async Task<IReadOnlyList<SearchResultItem>> GetMoviesAsync(MovieRangeType movieRangeType)
        {
            var web = new HtmlWeb();

            var url = $"{Configuration.BaseUrl}/{GetPopularPath(movieRangeType)}";
            var document = await web.LoadFromWebAsync(url).ConfigureAwait(false);

            return _overviewTransformer.Transform(document);
        }

        public async Task<IReadOnlyList<SearchResultItem>> GetForeignMoviesAsync(MovieRangeType movieRangeType)
        {
            var web = new HtmlWeb();

            var url = $"{Configuration.BaseUrl}/{GetPopularForeignPath(movieRangeType)}";
            var document = await web.LoadFromWebAsync(url).ConfigureAwait(false);

            return _overviewTransformer.Transform(document);
        }

        private string GetPopularPath(MovieRangeType popularRangeType)
        {
            if (popularRangeType == MovieRangeType.Today)
            {
                return "popular-movies";
            }

            return "popular-movies-week";
        }

        private string GetPopularForeignPath(MovieRangeType movieRangeType)
        {
            if (movieRangeType == MovieRangeType.Today)
            {
                return "popular-foreign-movies";
            }

            return "popular-foreign-movies-week";
        }
    }
}
