using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers;

[Route("api/search")]
[ApiController]
public class SearchController : BaseController
{
    private readonly IDataService _dataService;

    public SearchController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet("{searchWord}")]
    public IActionResult GetBestMatchSearch(string searchWord, int page = 0, int pageSize = 10)
    {
        (var bestMatchSearch, var total) = _dataService.GetBestMatchSearch(searchWord, page, pageSize);
        return Ok(bestMatchSearch);
    }
}
