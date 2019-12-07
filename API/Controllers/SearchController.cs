using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorrentReader.Search;
using TorrentReader.Search.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchProvider _searchProvider;

        public SearchController(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }

        [HttpGet]
        public Task<SearchResult> Get(string text, int page = 1, SearchSortByType sort = SearchSortByType.Seeders, SortOrderType order = SortOrderType.Descending)
        {
            return _searchProvider.SearchAsync(text, page, sort, order);
        }
        
    }
}
