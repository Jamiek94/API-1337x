using System.Collections.Generic;
using HtmlAgilityPack;
using TorrentReader.Search.Models;

namespace TorrentReader.Overview
{
    public interface IOverviewTransformer
    {
        IReadOnlyList<SearchResultItem> Transform(HtmlDocument document);
    }
}