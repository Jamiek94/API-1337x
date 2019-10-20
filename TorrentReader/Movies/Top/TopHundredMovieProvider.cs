using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TorrentReader.Config;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Movies.Top
{
    public class TopHundredMovieProvider : ITopHundredMovieProvider
    {
        private readonly IOverviewTransformer _overviewTransformer;

        public TopHundredMovieProvider(IOverviewTransformer overviewTransformer)
        {
            _overviewTransformer = overviewTransformer;
        }

        public async Task<IReadOnlyList<SearchResultItem>> GetAsync()
        {
            var web = new HtmlWeb();

            var url = $"{Configuration.BaseUrl}/top-100-movies";
            var document = await web.LoadFromWebAsync(url).ConfigureAwait(false);

            return _overviewTransformer.Transform(document);
        }
    }
}
