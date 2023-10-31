using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/nameworkedas")]
[ApiController]
public class NameWorkedAsController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public NameWorkedAsController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    private NameWorkedAsModel CreateNameWorkedAsModel(NameWorkedAs nameWorkedAs)
    {
        return new NameWorkedAsModel
        {
            Url = GetUrl(nameof(GetNameWorkedAs), new { nameWorkedAs.NameId, nameWorkedAs.Profession}),
            NameId = nameWorkedAs.NameId,
            Profession = nameWorkedAs.Profession
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}