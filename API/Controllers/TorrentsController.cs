using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader.Providers;
using TorrentReader.Providers.Trending;
using TorrentReader.Search.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentsController : ControllerBase
    {
        private readonly ITrendingTorrentsProvider _trendingTorrentsProvider;

        public TorrentsController(
            ITrendingTorrentsProvider trendingTorrentsProvider)
        {
            _trendingTorrentsProvider = trendingTorrentsProvider;
        }

        [HttpGet("trending")]
        public Task<IReadOnlyList<SearchResultItem>> GetTrending(TorrentPopularityRange movieRangeType)
        {
            return _trendingTorrentsProvider.GetAsync(movieRangeType);
        }
    }
}