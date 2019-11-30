using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader.Providers;
using TorrentReader.Providers.Games.Popular;
using TorrentReader.Providers.Games.Top;
using TorrentReader.Providers.Games.Trending;
using TorrentReader.Providers.Movies.Popular;
using TorrentReader.Providers.Movies.Top;
using TorrentReader.Providers.Movies.Trending;
using TorrentReader.Search.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IPopularGamesProvider _populairGamesProvider;

        private readonly ITrendingGamesProvider _trendingGamesProvider;

        private readonly ITopHundredGamesProvider _topHundredGamesProvider;

        public GamesController(
            IPopularGamesProvider popularGamesProvider,
            ITrendingGamesProvider trendingGamesProvider,
            ITopHundredGamesProvider tophundredGamesProvider)
        {
            _populairGamesProvider = popularGamesProvider;
            _trendingGamesProvider = trendingGamesProvider;
            _topHundredGamesProvider = tophundredGamesProvider;
        }

        [HttpGet("popular")]
        public Task<IReadOnlyList<SearchResultItem>> GetPopular(TorrentPopularityRange movieRangeType)
        {
            return _populairGamesProvider.GetAsync(movieRangeType);
        }

        [HttpGet("trending")]
        public Task<IReadOnlyList<SearchResultItem>> GetTrending(TorrentPopularityRange movieRangeType)
        {
            return _trendingGamesProvider.GetAsync(movieRangeType);
        }

        [HttpGet("top100")]
        public Task<IReadOnlyList<SearchResultItem>> GetTopHundred()
        {
            return _topHundredGamesProvider.GetAsync();
        }
    }
}