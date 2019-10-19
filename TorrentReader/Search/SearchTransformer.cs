using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TorrentReader.Search.Models;

namespace TorrentReader.Search
{
    public static class SearchTransformer
    {
        public static SearchResult Transform(HtmlDocument document, int page)
        {
            var tableItemNodeCollection = document.DocumentNode.SelectNodes("//table/tbody/tr");

            var searchResultItems = tableItemNodeCollection.Select(CreateSearchResultItem).ToList();

            var lastPageRelativeUrl = document.DocumentNode.SelectSingleNode("//*[contains(@class, 'pagination')]/ul/li[last()]/a[1]").GetAttributeValue("href", string.Empty);

            var amountPages = GetAmountPages(lastPageRelativeUrl);

            return new SearchResult(searchResultItems, amountPages, page);
        }

        private static int GetAmountPages(string relativeUrl)
        {
            var secondLastIndexOfSlash = relativeUrl.Substring(0, relativeUrl.Length - 1).LastIndexOf("/");

            var amountPages = relativeUrl.Substring(secondLastIndexOfSlash + 1, relativeUrl.Length - secondLastIndexOfSlash - 2);

            return int.Parse(amountPages);
        }

        private static SearchResultItem CreateSearchResultItem(HtmlNode tableItem)
        {
            var tdNodes = tableItem.SelectNodes("td");

            var name = tdNodes[0].InnerText;
            var commentsNode = tdNodes[0].SelectSingleNode("span");

            var relativeUrl = tdNodes[0].SelectSingleNode("a[2]").GetAttributeValue("href", string.Empty);
            var id = GetId(relativeUrl);
            var slug = GetSlug(relativeUrl);

            var amountComments = commentsNode != null ? int.Parse(commentsNode.InnerText) : 0;
            var amountSeeders = int.Parse(tdNodes[1].InnerText);
            var amountLeechers = int.Parse(tdNodes[2].InnerText);

            var uploadedOnCultureInfo = new CultureInfo("en-us");
            var uploadedOn = DateTime.ParseExact(StripDateAffix(tdNodes[3].InnerText), @"MMM\. d \'yy", uploadedOnCultureInfo);

            var size = tdNodes[4].SelectSingleNode("text()").InnerText;
            var uploaderName = tdNodes[5].SelectSingleNode("a[1]").InnerText;

            return new SearchResultItem(name, amountComments, amountSeeders, amountLeechers, uploadedOn, size, uploaderName, id, slug);
        }

        private static int GetId(string relativeUrl)
        {
            var indexSecondSlash = relativeUrl.IndexOf("/", 1, StringComparison.Ordinal);
            var indexThirdSlash = relativeUrl.IndexOf("/", indexSecondSlash + 1, StringComparison.Ordinal);

            return int.Parse(relativeUrl.Substring(indexSecondSlash + 1, indexThirdSlash - indexSecondSlash - 1));
        }

        private static string GetSlug(string relativeUrl)
        {
            var indexSecondToLastSlash = relativeUrl.LastIndexOf("/", relativeUrl.Length - 2, StringComparison.Ordinal);

            return relativeUrl.Substring(indexSecondToLastSlash + 1, relativeUrl.Length - indexSecondToLastSlash - 2);
        }

        private static string StripDateAffix(string date)
        {
            var affixes = new List<string> { "st", "nd", "th" };

            var modifiedDate = date;

            affixes.ForEach(affix => modifiedDate = modifiedDate.Replace(affix, string.Empty));

            return modifiedDate;
        }
    }
}
