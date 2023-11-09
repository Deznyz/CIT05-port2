using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/searchhistory")]
[ApiController]
public class SearchHistoryController : BaseController
{
    private readonly IDataService _dataService;

        public SearchHistoryController(IDataService dataService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _dataService = dataService;

        }

        [HttpGet(Name = nameof(GetSearchHistory))]
        public IActionResult GetSearchHistory(int page = 0, int pageSize = 10)
        {
            (var SearchHistory, var total) = _dataService.GetSearchHistory(page, pageSize);

            var items = SearchHistory.Select(CreateSearchHistoryModel);

            var result = Paging(items, total, page, pageSize, nameof(GetSearchHistory));

            return Ok(result);

        }

        //[HttpGet("{nameId}")]
        //public IActionResult GetSearchHistory(int SearchHistoryId, int page, int pageSize)
        //{
        //    (var searchHistory, var total) = _dataService.GetSearchHistory(SearchHistoryId, page, pageSize);

        //    var items = searchHistory.Select(CreateSearchHistoryModel);

        //    var result = Paging(items, total, page, pageSize, nameof(GetSearchHistory));

        //    return Ok(result);

        //}

        [HttpGet("{SearchHistoryId}")]
        public IActionResult GetSearchHistoryId(int SearchHistoryId)
        {
            var searchHistory = _dataService.GetSearchHistory(SearchHistoryId);
            if (SearchHistoryId == null)
            {
                return NotFound();
            }

            return Ok(CreateSearchHistoryModel(searchHistory));
        }


    [HttpPut("{searchHistoryd}", Name = nameof(UpdateSearchHistory))]
    public IActionResult UpdateSearchHistory(int searchHistoryId, CreateSearchHistoryModel model)
    {
        var existSearchHistory = _dataService.GetSearchHistory(searchHistoryId);

        if (existSearchHistory != null)
        {
            var updateSearchHistory = new SearchHistory
            {
                SearchHistoryId = model.SearchHistoryId,
                UserId = model.UserId,
                Searched = model.Searched
            };

            _dataService.UpdateSearchHistory(searchHistoryId, updateSearchHistory);
            return Ok(existSearchHistory);
        }
        else
        {
            return NotFound();

        }
    }


            [HttpPost]
        public IActionResult GetSearchHistory(CreateSearchHistoryModel model)
        {
            var searchHistory = new SearchHistory
            {
                SearchHistoryId = model.SearchHistoryId,
                UserId = model.UserId,
                Searched = model.Searched
            };

            _dataService.CreateSearchHistory(searchHistory);

            var searchHistoryUri = Url.Link("GetSearchHistory", new { searchHistoryId = searchHistory.SearchHistoryId});

            return Created(searchHistoryUri, searchHistory);
        }

        private SearchHistoryModel CreateSearchHistoryModel(SearchHistory searchHistory)
        {
            return new SearchHistoryModel
            {
                Url = GetUrl(nameof(GetSearchHistory), new { searchHistory.SearchHistoryId}),
                SearchHistoryId = searchHistory.SearchHistoryId,
                UserId = searchHistory.UserId,
                Searched = searchHistory.Searched
            };
        }
}