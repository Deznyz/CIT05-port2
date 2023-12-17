using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers;

[Route("api/exactsearch")]
[ApiController]
public class ExactSearchController : BaseController
{
    private readonly IDataService _dataService;

    public ExactSearchController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet("{titleId}")]
    public IActionResult GetExactSearch(string titleId)
    {
        (var exactSearch, var total) = _dataService.GetExactSearch(titleId, 0, 10);
        return Ok(exactSearch);

    }
}
