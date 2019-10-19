using System.Collections.Generic;

namespace TorrentReader.Torrent.Models
{
    public class Torrent
    {
        public TorrentDetail Detail { get; set; }

        public IReadOnlyList<Comment> Comments { get; set; }

        public Torrent(TorrentDetail detail, IReadOnlyList<Comment> comments)
        {
            Detail = detail;
            Comments = comments;
        }
    }
}
