using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/frontend")]
[ApiController]
public class FrontendController : BaseController
{
    private readonly IDataService _dataService;

    public FrontendController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetFrontends))]
    public IActionResult GetFrontends(int page = 0, int pageSize = 10)
    {
        (var frontends, var total) = _dataService.GetFrontends(page, pageSize);

        var items = frontends.Select(CreateFrontendModel);

        var result = Paging(items, total, page, pageSize, nameof(GetFrontends));

        return Ok(result);

    }

    [HttpGet("{titleId}")]
    public IActionResult GetFrontendsByTitleId(string titleId, int page, int pageSize)
    {
        (var frontends, var total) = _dataService.GetFrontendsByTitleId(titleId, page, pageSize);

        var items = frontends.Select(CreateFrontendModel);

        var result = Paging(items, total, page, pageSize, nameof(GetFrontends));

        return Ok(result);

    }

    [HttpGet("{titleId}/{poster}", Name = nameof(GetFrontend))]
    public IActionResult GetFrontend(string titleId, string poster)
    {
        var frontend = _dataService.GetFrontend(titleId, poster);
        if (frontend == null)
        {
            return NotFound();
        }

        return Ok(CreateFrontendModel(frontend));
    }

    [HttpPost]
    public IActionResult CreateFrontend(CreateFrontendModel model)
    {
        var frontend = new Frontend
        {
            TitleId = model.TitleId,
            Poster = model.Poster
        };

        _dataService.CreateFrontend(frontend);

        var frontendUri = Url.Link("GetBookmarksTitle", new { titleId = frontend.TitleId, poster = frontend.Poster });

        return Created(frontendUri, frontend);
    }



    private FrontendModel CreateFrontendModel(Frontend frontend)
    {
        return new FrontendModel
        {
            Url = GetUrl(nameof(GetFrontend), new { frontend.TitleId, frontend.Poster }),
            TitleId = frontend.TitleId,
            Poster = frontend.Poster,
            Plot = frontend.Plot
        };
    }

}