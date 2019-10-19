using Newtonsoft.Json;

namespace TorrentReader.Torrent.Models
{
    public class Comment
    {
        public string Username { get; set; }

        [JsonProperty("comment")]
        public string Text { get; set; }

        [JsonProperty("posted")]
        public string DatePostedOn { get; set; }
    }
}
