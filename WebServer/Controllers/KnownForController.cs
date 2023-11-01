using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/knownfor")]
[ApiController]
public class KnownForController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public KnownForController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private KnownForModel CreateKnownForModel(KnownFor knownFor)
    //{
    //    return new KnownForModel
    //    {
    //        Url = GetUrl(nameof(GetKnownFor), new { knownFor.TitleId, knownFor.NameId }),
    //        NameId = knownFor.NameId,
    //        TitleId = knownFor.TitleId
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}