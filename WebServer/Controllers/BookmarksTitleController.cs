using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/bookmarkstitle")]
[ApiController]
public class BookmarksTitleController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public BookmarksTitleController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private BookmarksTitleModel CreateBookmarksTitleModel(BookmarksTitle bookmarksTitle)
    //{
    //    return new BookmarksTitleModel
    //    {
    //        Url = GetUrl(nameof(GetBookmarksName), new { bookmarksTitle.UserId, bookmarksTitle.TitleId }),
    //        TitleId = bookmarksTitle.TitleId,
    //        UserId = bookmarksTitle.UserId
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}