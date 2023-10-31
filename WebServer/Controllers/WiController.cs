using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/wi")]
[ApiController]
public class WiController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public WiController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    private WiModel CreateWiModel(Wi wi)
    {
        return new WiModel
        {
            Url = GetUrl(nameof(GetWi), new { wi.TitleId, wi.Word, wi.Field }),
            TitleId = wi.TitleId,
            Word = wi.Word,
            Field = wi.Field,
            Lexeme = wi.Lexeme
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}