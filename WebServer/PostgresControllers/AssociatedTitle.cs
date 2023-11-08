using DataLayer;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/associatedtitle")]
[ApiController]
public class AssociatedTitleController : BaseController
{
    private readonly IDataService _dataService;

    public AssociatedTitleController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet("{title}/associatedtitle")]
    public IActionResult GetAssociatedTitle(string titleId)
    {
        (var associatedtitle, var total) = _dataService.GetAssociatedTitle(titleId, 0, 10);
        return Ok(associatedtitle);

    }

}

