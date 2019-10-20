using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Search.Models;

namespace TorrentReader.Movies.Trending
{
    public interface ITrendingMovieProvider
    {
        Task<IReadOnlyList<SearchResultItem>> GetAsync(MovieRangeType movieRangeType);
    }
}