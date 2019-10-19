﻿using System.Collections.Generic;

namespace TorrentReader.Torrent.Models
{
    public class TorrentDetail
    {
        public string Category { get; set; }

        public string Type { get; set; }

        public string Language { get; set; }

        public string TotalSize { get; set; }

        public string UploadedBy { get; set; }

        public int AmountDownloads { get; set; }

        public string DateLastChecked { get; set; }

        public string DateUploaded { get; set; }

        public int AmountSeeders { get; set; }

        public int AmountLeechers { get; set; }

        public string HtmlDescription { get; set; }

        public string InfoHash { get; set; }

        public IReadOnlyList<string> Files { get; set; }

        public TorrentDetail(
            string category,
            string type,
            string language,
            string totalSize,
            string uploadedBy,
            int amountDownloads,
            string dateLastChecked,
            string dateUploaded,
            int amountSeeders,
            int amountLeechers,
            string htmlDescription,
            string infoHash,
            IReadOnlyList<string> files)
        {
            Category = category;
            Type = type;
            Language = language;
            TotalSize = totalSize;
            UploadedBy = uploadedBy;
            AmountDownloads = amountDownloads;
            DateLastChecked = dateLastChecked;
            DateUploaded = dateUploaded;
            AmountSeeders = amountSeeders;
            AmountLeechers = amountLeechers;
            HtmlDescription = htmlDescription;
            InfoHash = infoHash;
            Files = files;
        }
    }
}