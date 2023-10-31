using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/principals")]
[ApiController]
public class PrincipalsController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public PrincipalsController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    private PrincipalsModel CreatePrincipalsModel(Principals principals)
    {
        return new PrincipalsModel
        {
            Url = GetUrl(nameof(GetPrincipals), new { principals.PrincipalsId }),
            PrincipalsId = principals.PrincipalsId,
            TitleId = principals.TitleId,
            Ordering = principals.Ordering,
            NameId = principals.NameId,
            JobCategory = principals.JobCategory,
            Job = principals.Job,
            Role = principals.Role
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}