using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/bookmarksname")]
[ApiController]
public class BookmarksNameController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public BookmarksNameController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    private BookmarksNameModel CreateBookmarksNameModel(BookmarksName bookmarksName)
    {
        return new BookmarksNameModel
        {
            Url = GetUrl(nameof(GetBookmarksName), new { bookmarksName.UserId, bookmarksName.NameId }),
            NameId = bookmarksName.NameId,
            UserId = bookmarksName.UserId
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}