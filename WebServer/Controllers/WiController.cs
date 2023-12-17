using DataLayer;
using Microsoft.AspNetCore.Mvc;

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


    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}