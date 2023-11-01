using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;
[Route("api/aliases")]
[ApiController]
public class AliasesController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public AliasesController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }

    

    private AliasesModel CreateAliasesModel(Aliases aliases)
    {
        return new AliasesModel
        {
            Url = GetUrl(nameof(GetAliases), new { aliases.TitleId, aliases.Ordering }),
            TitleId = aliases.TitleId,
            Ordering = aliases.Ordering,
            Title = aliases.Title,
            Region = aliases.Region,
            Language = aliases.Language,
            IsOriginalTitle = aliases.IsOriginalTitle,
            Types = aliases.Types,
            Attributes = aliases.Attributes
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}
