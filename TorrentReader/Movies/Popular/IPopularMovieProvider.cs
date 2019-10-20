using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Search.Models;

namespace TorrentReader.Movies.Popular
{
    public interface IPopularMovieProvider
    {
        Task<IReadOnlyList<SearchResultItem>> GetMoviesAsync(MovieRangeType movieRangeType);

        Task<IReadOnlyList<SearchResultItem>> GetForeignMoviesAsync(MovieRangeType movieRangeType);
    }
}