using System.Threading.Tasks;

namespace TorrentReader.Torrent.Provider
{
    public interface ITorrentDetailProvider
    {
        Task<Models.Torrent> GetAsync(int torrentId, string slug);
    }
}