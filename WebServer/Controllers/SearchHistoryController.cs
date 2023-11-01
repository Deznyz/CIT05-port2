using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/searchhistory")]
[ApiController]
public class SearchHistoryController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public SearchHistoryController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private SearchHistoryModel CreateSearchHistoryModel(SearchHistory searchHistory)
    //{
    //    return new SearchHistoryModel
    //    {
    //        Url = GetUrl(nameof(GetSearchHistory), new { searchHistory.SearchHistoryId }),
    //        SearchHistoryId = searchHistory.SearchHistoryId,
    //        UserId = searchHistory.UserId,
    //        Searched = searchHistory.Searched
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}