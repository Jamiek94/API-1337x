using Microsoft.Extensions.DependencyInjection;
using TorrentReader.Http;
using TorrentReader.Movies.Popular;
using TorrentReader.Movies.Top;
using TorrentReader.Movies.Trending;
using TorrentReader.Overview;
using TorrentReader.Search;
using TorrentReader.Torrent.Provider;
using TorrentReader.Torrent.Transformer;

namespace TorrentReader.Di
{
    public static class DiConfig
    {
        public static void ConfigureTorrentReaderServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpProvider, HttpProvider>();

            serviceCollection.AddTransient<IPopularMovieProvider, PopularMovieProvider>();
            serviceCollection.AddTransient<ITrendingMovieProvider, TrendingMovieProvider>();

            serviceCollection.AddTransient<IOverviewTransformer, OverviewTransformer>();

            serviceCollection.AddTransient<ISearchProvider, SearchProvider>();
            serviceCollection.AddTransient<ISearchTransformer, SearchTransformer>();

            serviceCollection.AddTransient<ITorrentProvider, TorrentProvider>();
            serviceCollection.AddTransient<ITorrentDetailTransformer, TorrentDetailTransformer>();

            serviceCollection.AddTransient<ITopHundredMovieProvider, TopHundredMovieProvider>();
        }
    }
}
