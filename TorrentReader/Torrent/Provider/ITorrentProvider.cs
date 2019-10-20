using System.Threading.Tasks;

namespace TorrentReader.Torrent.Provider
{
    public interface ITorrentProvider
    {
        Task<Models.Torrent> GetAsync(int torrentId, string slug);
    }
}