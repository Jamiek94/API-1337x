using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using TorrentReader.Config;
using TorrentReader.Http;
using TorrentReader.Torrent.Models;
using TorrentReader.Torrent.Transformer;

namespace TorrentReader.Torrent.Provider
{
    public class TorrentProvider : ITorrentProvider
    {
        private readonly IHttpProvider _httpProvider;

        private readonly ITorrentDetailTransformer _torrentDetailTransformer;

        public TorrentProvider(IHttpProvider httpProvider, ITorrentDetailTransformer torrentDetailTransformer)
        {
            _httpProvider = httpProvider;
            _torrentDetailTransformer = torrentDetailTransformer;
        }

        public async Task<Models.Torrent> GetAsync(int torrentId, string slug)
        {
            var torrentUrl = $"{Configuration.BaseUrl}/torrent/{torrentId}/{slug}/";

            var web = new HtmlWeb();

            var documentTask = web.LoadFromWebAsync(torrentUrl).ConfigureAwait(false);
            var commentsTask = GetCommentsAsync(torrentId).ConfigureAwait(false);

            var document = await documentTask;
            var comments = await commentsTask;

            var detail = _torrentDetailTransformer.Transform(document);

            return new Models.Torrent(detail, comments);
        }

        private Task<IReadOnlyList<Comment>> GetCommentsAsync(int torrentId)
        {
            var commentsUrl = $"/comments.php?torrentid={torrentId}";

            return _httpProvider.GetAsync<Comment>(commentsUrl);
        }
    }
}
