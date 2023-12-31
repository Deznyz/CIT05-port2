using DataLayer;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("{word}")]
    public IActionResult GetAssociatedWords(string word)
    {
        (var associatedWords, var total) = _dataService.GetAssociatedWords(word, 0, 10);
        return Ok(associatedWords);

    }
}

