using DataLayer;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/structuredstringsearch")]
[ApiController]
public class StructuredStringSearchController : BaseController
{
    private readonly IDataService _dataService;

    public StructuredStringSearchController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet("{title}/StructuredStringSearch")]
    public IActionResult GetStructuredStringSearch(string tconst)
    {
        (var structuredStringSearch, var total) = _dataService.GetStructuredStringSearch(tconst, 0, 10);
        return Ok(structuredStringSearch);

    }
}
