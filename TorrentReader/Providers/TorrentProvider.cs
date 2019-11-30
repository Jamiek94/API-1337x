using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Config;
using TorrentReader.Overview;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers
{
    public abstract class TorrentProvider
    {
        private readonly IOverviewTransformer _overviewTransformer;

        public TorrentProvider(IOverviewTransformer overviewTransformer)
        {
            _overviewTransformer = overviewTransformer;
        }

        protected async Task<IReadOnlyList<SearchResultItem>> Get(string popularityRangePath)
        {
            var web = new HtmlWeb();

            var url = $"{Configuration.BaseUrl}/{popularityRangePath}";
            var document = await web.LoadFromWebAsync(url).ConfigureAwait(false);

            return _overviewTransformer.Transform(document);
        }
    }
}
