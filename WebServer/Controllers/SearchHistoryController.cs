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

    [HttpGet("{searchHistoryId}")]
    public IActionResult GetSearchHistory(int searchHistoryId, int page = 0, int pageSize = 10)
    {
        (var searchHistory, var total) = _dataService.GetSearchHistory(searchHistoryId, page, pageSize);

        var items = searchHistory.Select(CreateSearchHistoryModel);

        var result = Paging(items, total, page, pageSize, nameof(GetSearchHistory));

        return Ok(result);

    }

    [HttpGet("{SearchHistoryId}/{nameId}", Name = nameof(GetSearchHistoryId))]
        public IActionResult GetSearchHistoryId(int SearchHistoryId, int userId)
        {
            var searchHistory = _dataService.GetSearchHistoryId(SearchHistoryId, userId);
            if (searchHistory == null)
            {
                return NotFound();
            }

            return Ok(CreateSearchHistoryModel(searchHistory));
        }


    [HttpPut("{searchHistoryId}/{nameId}", Name = nameof(UpdateSearchHistory))]
    public IActionResult UpdateSearchHistory(int searchHistoryId, int userId, CreateSearchHistoryModel model)
    {
        var existSearchHistory = _dataService.GetSearchHistoryId(searchHistoryId, userId);

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
        public IActionResult CreateSearchHistory(CreateSearchHistoryModel model)
        {
            var searchHistory = new SearchHistory
            {
                SearchHistoryId = model.SearchHistoryId,
                UserId = model.UserId,
                Searched = model.Searched
            };

            _dataService.CreateSearchHistory(searchHistory);

            var searchHistoryUri = Url.Link("GetSearchHistory", new { searchHistoryId = searchHistory.SearchHistoryId, userId = searchHistory.UserId});

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