# API-1337x
API for scraping 1337x.to

## API Calls
There are currently 2 API calls supported.

### Searching
Possible query parameters: search, page, sort, order.

- http://localhost:5000/api/Search?search=game of thrones
 
### Torrent detail
Both id + slug are required.

- http://localhost:5000/api/torrent?id=3769746&slug=Game-of-Thrones-S08E06-720p-WEB-H264-MEMENTO-eztv
