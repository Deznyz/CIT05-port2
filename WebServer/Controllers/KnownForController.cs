using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/knownfor")]
[ApiController]
public class KnownForController : BaseController
{
    private readonly IDataService _dataService;

    public KnownForController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetKnownFors))]
    public IActionResult GetKnownFors(int page = 0, int pageSize = 10)
    {


        (var knownFor, var total) = _dataService.GetKnownFors(page, pageSize);

        var items = knownFor.Select(CreateKnownforModel);

        var result = Paging(items, total, page, pageSize, nameof(GetKnownFors));

        return Ok(result);

    }

    [HttpGet("titleid/{titleId}")]
    public IActionResult GetKnownForTitle(string titleId, int page, int pageSize)
    {

        (var knownFor, var total) = _dataService.GetKnownForTitle(titleId, page, pageSize);

        var items = knownFor.Select(CreateKnownforModel);

        var result = Paging(items, total, page, pageSize, nameof(GetKnownFors));

        return Ok(result);

    }

    [HttpGet("nameid/{nameId}")]
    public IActionResult GetKnownForName(string nameId, int page, int pageSize)
    {

        (var knownFor, var total) = _dataService.GetKnownForName(nameId, page, pageSize);

        var items = knownFor.Select(CreateKnownforModel);

        var result = Paging(items, total, page, pageSize, nameof(GetKnownFors));

        return Ok(result);

    }

    [HttpGet("specific/{titleId}/{nameId}", Name = nameof(GetKnownFor))]
    public IActionResult GetKnownFor(string titleId, string genreData)
    {
        var knownFor = _dataService.GetKnownFor(titleId, genreData);
        if (knownFor == null)
        {
            return NotFound();
        }

        return Ok(CreateKnownforModel(knownFor));
    }

    [HttpPost]
    public IActionResult CreateKnownFor(CreateKnownForModel model)
    {
        var knownFor = new KnownFor
        {
            TitleId = model.TitleId,
            NameId = model.NameId
        };

        _dataService.CreateKnownFor(knownFor);

        var knownForUri = Url.Link("GetKnownFor", new { titleId = knownFor.TitleId, nameId = knownFor.NameId });

        return Created(knownForUri, knownFor);
    }

    private KnownForModel CreateKnownforModel(KnownFor knownFor)
    {
        return new KnownForModel
        {
            Url = GetUrl(nameof(GetKnownFor), new { knownFor.TitleId, knownFor.NameId }),
            TitleId = knownFor.TitleId,
            NameId = knownFor.NameId
        };
    }

    //private string? GetUrl(string name, object values)
    //{
    //    return _linkGenerator.GetUriByName(HttpContext, name, values);
    //}

}