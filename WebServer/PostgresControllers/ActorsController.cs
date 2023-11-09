using DataLayer;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/actors")]
[ApiController]
public class ActorsController : BaseController
{
    private readonly IDataService _dataService;

    public ActorsController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet("{name}/coactors")]
    public IActionResult GetCoActors(string name) {
        (var coActors, var total) = _dataService.GetCoActors(name, 0, 10);
        return Ok(coActors);

    }

}

