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

    [HttpGet("{name}")]
    public IActionResult NameSearch(string name, int page = 0, int pageSize =10)
    {
        (var nameSearchResult, var total) = _dataService.NameSearch(name, page, pageSize);

        return Ok(nameSearchResult);

    }

    [HttpGet("{name}/coactors")]
    public IActionResult GetCoActors(string name, int page = 0, int pageSize = 10) {
        (var coActors, var total) = _dataService.GetCoActors(name, page, pageSize);
        return Ok(coActors);

    }

    [HttpGet("{id}/weightedaverage")]
    public IActionResult GetWeightedAverage(string id)
    {
        var weightedAverage = _dataService.GetWeightedAverage(id);
        return Ok(weightedAverage);

    }

}

