using DataLayer;
using DataLayer.Models;
using DataLayer.PostgresModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/associatedwords")]
[ApiController]
public class AssociatedWordsController : BaseController
{
    private readonly IDataService _dataService;

    public AssociatedWordsController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet("{title}/associatedwords")]
    public IActionResult GetAssociatedWords(string titleId)
    {
        (var associatedWords, var total) = _dataService.GetAssociatedWords(titleId, 0, 10);
        return Ok(associatedWords);

    }

}

