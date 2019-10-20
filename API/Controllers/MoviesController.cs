using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader.Movies;
using TorrentReader.Movies.Popular;
using TorrentReader.Movies.Trending;
using TorrentReader.Search.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IPopularMovieProvider _popularMovieProvider;

        private readonly ITrendingMovieProvider _trendingMovieProvider;

        public MoviesController(IPopularMovieProvider popularMovieProvider, ITrendingMovieProvider trendingMovieProvider)
        {
            _popularMovieProvider = popularMovieProvider;
            _trendingMovieProvider = trendingMovieProvider;
        }

        [HttpGet("popular")]
        public Task<IReadOnlyList<SearchResultItem>> GetPopular(MovieRangeType movieRangeType)
        {
            return _popularMovieProvider.GetMoviesAsync(movieRangeType);
        }

        [HttpGet("popular-foreign")]
        public Task<IReadOnlyList<SearchResultItem>> GetPopularForeign(MovieRangeType movieRangeType)
        {
            return _popularMovieProvider.GetForeignMoviesAsync(movieRangeType);
        }

        [HttpGet("trending")]
        public Task<IReadOnlyList<SearchResultItem>> GetTrending(MovieRangeType movieRangeType)
        {
            return _trendingMovieProvider.GetAsync(movieRangeType);
        }
    }
}