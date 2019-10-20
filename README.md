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

### Movies
Currently supported; popular (day, last week), foreign (day, last week), trending (day, last week) and top 100.

#### Popular movies
Day + week
http://localhost:5000/api/movies/popular?movieRangeType=0
http://localhost:5000/api/movies/popular?movieRangeType=1

#### Populair foreign movies
Day + week
http://localhost:5000/api/movies/popular-foreign?movieRangeType=0
http://localhost:5000/api/movies/popular-foreign?movieRangeType=1

#### Trending
Day + week
http://localhost:5000/api/movies/trending?movieRangeType=0
http://localhost:5000/api/movies/trending?movieRangeType=1

#### Top 100
Day + week
http://localhost:5000/api/movies/top100
