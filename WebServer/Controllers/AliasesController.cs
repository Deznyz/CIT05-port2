using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/aliases")]
[ApiController]
public class AliasesController : BaseController
{
    private readonly IDataService _dataService;

    public AliasesController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetAliases))]
    public IActionResult GetAliases(int page=0, int pageSize=10)
    {
        //var result = _dataService.GetAliases().Select(CreateAliasesModel);
        //return Ok( result);

        (var aliases, var total) = _dataService.GetAliases(page, pageSize);

        var items = aliases.Select(CreateAliasesModel);

        var result = Paging(items, total, page, pageSize, nameof(GetAliases));

        return Ok(result);

    }

    [HttpGet("{titleId}")]
    public IActionResult GetAliases(string titleId, int page, int pageSize)
    {
            //var result = _dataService.GetAliases(titleId, 0, 10).Select(CreateAliasesModel);
            //return Ok(result);

        (var aliases, var total) = _dataService.GetAliases(titleId, page, pageSize);

        var items = aliases.Select(CreateAliasesModel);

        var result = Paging(items, total, page, pageSize, nameof(GetAliases));

        return Ok(result);

    }

    [HttpGet("{titleId}/{ordering}", Name = nameof(GetAlias))]
    public IActionResult GetAlias(string titleId, int ordering)
    {
        var aliases = _dataService.GetAlias(titleId, ordering);
        if (aliases == null)
        {
            return NotFound();
        }

        return Ok(CreateAliasesModel(aliases));
    }

    [HttpPost]
    public IActionResult CreateAliases(CreateAliasesModel model)
    {
        var alias = new Aliases
        {
            TitleId = model.TitleId,
            Ordering = model.Ordering,
            Title = model.Title,
            Region = model.Region,
            Language = model.Language,
            IsOriginalTitle = model.IsOriginalTitle,
            Types = model.Types,
            Attributes = model.Attributes
        };

        _dataService.CreateAliases(alias);

        var aliasUri = Url.Link("GetAlias", new { titleId = alias.TitleId, ordering = alias.Ordering });

        return Created(aliasUri, alias);
    }

    private AliasesModel CreateAliasesModel(Aliases aliases)
    {
        return new AliasesModel
        {
            Url = GetUrl(nameof(GetAlias), new { aliases.TitleId, aliases.Ordering }),
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

    //private string? GetUrl(string name, object values)
    //{
    //    return _linkGenerator.GetUriByName(HttpContext, name, values);
    //}

}
