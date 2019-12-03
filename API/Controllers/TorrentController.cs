using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader.Torrent;
using TorrentReader.Torrent.Models;
using TorrentReader.Torrent.Provider;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentController : ControllerBase
    {
        private readonly ITorrentDetailProvider _torrentProvider;

        public TorrentController(ITorrentDetailProvider torrentProvider)
        {
            _torrentProvider = torrentProvider;
        }

        [HttpGet]
        public Task<Torrent> Get(int id, string slug)
        {
            return _torrentProvider.GetAsync(id, slug);
        }
        
    }
}
