using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/frontend")]
[ApiController]
public class FrontendController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public FrontendController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
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

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}