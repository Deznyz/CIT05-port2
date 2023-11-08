using DataLayer;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

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

    [HttpGet("{title}/ExactSearch")]
    public IActionResult GetExactSearch(string titleId)
    {
        (var exactSearch, var total) = _dataService.GetExactSearch(titleId, 0, 10);
        return Ok(exactSearch);

    }
}
