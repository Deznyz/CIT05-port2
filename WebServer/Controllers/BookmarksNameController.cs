using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/bookmarksname")]
[ApiController]
public class BookmarksNameController : BaseController
{
    private readonly IDataService _dataService;

    public BookmarksNameController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetBookmarksName))]
    public IActionResult GetBookmarksName(int page = 0, int pageSize = 10)
    {
        //var result = _dataService.GetAliases().Select(CreateAliasesModel);
        //return Ok( result);

        (var bookmarksNames, var total) = _dataService.GetBookmarksName(page, pageSize);

        var items = bookmarksNames.Select(CreateBookmarksNameModel);

        var result = Paging(items, total, page, pageSize, nameof(GetBookmarksName));

        return Ok(result);

    }

    [HttpGet("{userId}")]
    public IActionResult GetBookmarksName(int userId, int page=0, int pageSize=10)
    {
        //var result = _dataService.GetAliases(titleId, 0, 10).Select(CreateAliasesModel);
        //return Ok(result);

        (var bookmarksName, var total) = _dataService.GetBookmarksName(userId, page, pageSize);

        var items = bookmarksName.Select(CreateBookmarksNameModel);

        var result = Paging(items, total, page, pageSize, nameof(GetBookmarksName));

        return Ok(result);

    }

    [HttpGet("{userId}/{nameId}", Name = nameof(GetSpecificBookmarksName))]
    public IActionResult GetSpecificBookmarksName(int userId, string nameId)
    {
        var bookmarksName = _dataService.GetSpecificBookmarksName(userId, nameId);
        if (bookmarksName == null)
        {
            return NotFound();
        }

        return Ok(CreateBookmarksNameModel(bookmarksName));
    }

    [HttpPost]
    public IActionResult CreateBookmarksName(CreateBookmarksNameModel model)
    {
        var bookmarksName = new BookmarksName
        {
            UserId = model.UserId,
            NameId = model.NameId
        };

        _dataService.CreateBookmarksName(bookmarksName);

        var bookmarksNameUri = Url.Link("GetBookmarksName", new { userId = bookmarksName.UserId, nameId = bookmarksName.NameId });

        return Created(bookmarksNameUri, bookmarksName);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBookmarksName(BookmarksName bookmarksName)
    {

        return Ok();

    }

    private BookmarksNameModel CreateBookmarksNameModel(BookmarksName bookmarksName)
    {
        return new BookmarksNameModel
        {
            Url = GetUrl(nameof(GetSpecificBookmarksName), new { bookmarksName.UserId, bookmarksName.NameId }),
            UserId = bookmarksName.UserId,
            NameId = bookmarksName.NameId,
            
           
        };
    }

    

}

