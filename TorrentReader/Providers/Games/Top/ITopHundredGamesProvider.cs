using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Games.Top
{
    public interface ITopHundredGamesProvider
    {
        Task<IReadOnlyList<SearchResultItem>> GetAsync();
    }
}