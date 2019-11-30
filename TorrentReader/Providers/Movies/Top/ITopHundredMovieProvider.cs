﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentReader.Search.Models;

namespace TorrentReader.Providers.Movies.Top
{
    public interface ITopHundredMovieProvider
    {
        Task<IReadOnlyList<SearchResultItem>> GetAsync();
    }
}