using System.Collections.Generic;
using HtmlAgilityPack;
using System.Threading.Tasks;
using TorrentReader.Config;
using TorrentReader.Http;
using TorrentReader.Torrent.Models;

namespace TorrentReader.Torrent
{
    public class TorrentProvider
    {
        public async Task<Models.Torrent> GetAsync(int torrentId, string slug)
        {
            var torrentUrl = $"{Configuration.BaseUrl}/torrent/{torrentId}/{slug}/";

            var web = new HtmlWeb();

            var documentTask = web.LoadFromWebAsync(torrentUrl).ConfigureAwait(false);
            var commentsTask = GetCommentsAsync(torrentId).ConfigureAwait(false);

            var document = await documentTask;
            var comments = await commentsTask;

            var detail = TorrentDetailTransformer.Transform(document);

            return new Models.Torrent(detail, comments);
        }

        private Task<IReadOnlyList<Comment>> GetCommentsAsync(int torrentId)
        {
            var commentsUrl = $"/comments.php?torrentid={torrentId}";

            return HttpProvider.GetAsync<Comment>(commentsUrl);
        }
    }
}
