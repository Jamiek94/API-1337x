using HtmlAgilityPack;

namespace TorrentReader.Torrent.Transformer
{
    public interface ITorrentDetailTransformer
    {
        Models.TorrentDetail Transform(HtmlDocument document);
    }
}