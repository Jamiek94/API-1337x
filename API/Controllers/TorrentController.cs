using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader.Torrent;
using TorrentReader.Torrent.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentController : ControllerBase
    {
        private readonly TorrentProvider _torrentProvider;

        public TorrentController()
        {
            _torrentProvider = new TorrentProvider();
        }

        [HttpGet]
        public Task<Torrent> Get(int id, string slug)
        {
            return _torrentProvider.GetAsync(id, slug);
        }
        
    }
}
