using HtmlAgilityPack;
using TorrentReader.Search.Models;

namespace TorrentReader.Search
{
    public interface ISearchTransformer
    {
        SearchResult Transform(HtmlDocument document, int page);
    }
}