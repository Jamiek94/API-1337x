using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader;
using TorrentReader.Search;
using TorrentReader.Search.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchProvider _searchProvider;

        public SearchController()
        {
            _searchProvider = new SearchProvider();
        }

        [HttpGet]
        public Task<SearchResult> Get(string search, int page = 1, SearchSortByType sort = SearchSortByType.Seeders, SortOrderType order = SortOrderType.Descending)
        {
            return _searchProvider.SearchAsync(search, page, sort, order);
        }
        
    }
}
