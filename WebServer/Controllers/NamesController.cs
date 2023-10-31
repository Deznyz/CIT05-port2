using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/names")]
[ApiController]
public class NamesController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public NamesController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    private NamesModel CreateNamesModel(Names names)
    {
        return new NamesModel
        {
            Url = GetUrl(nameof(GetNames), new { names.NameId }),
            NameId = names.NameId,
            Name = names.Name,
            BirthYear = names.BirthYear,
            DeathYear = names.DeathYear,
            AvgNameRating = names.AvgNameRating
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}