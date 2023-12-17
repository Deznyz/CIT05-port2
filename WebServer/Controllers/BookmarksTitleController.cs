using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/bookmarkstitle")]
[ApiController]
public class BookmarksTitleController : BaseController
{
    private readonly IDataService _dataService;

    public BookmarksTitleController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetBookmarksTitles))]
    public IActionResult GetBookmarksTitles(int page = 0, int pageSize = 10)
    {
        (var bookmarksTitle, var total) = _dataService.GetBookmarksTitles(page, pageSize);

        var items = bookmarksTitle.Select(CreateBookmarksTitleModel);

        var result = Paging(items, total, page, pageSize, nameof(GetBookmarksTitles));

        return Ok(result);

    }

    [HttpGet("{userId}")]
    public IActionResult GetBookmarksTitles(int userId, int page=0, int pageSize=10)
    {
        (var bookmarksTitles, var total) = _dataService.GetBookmarksTitles(userId, page, pageSize);

        var items = bookmarksTitles.Select(CreateBookmarksTitleModel);

        var result = Paging(items, total, page, pageSize, nameof(GetBookmarksTitles));

        return Ok(result);

    }

    [HttpGet("{userId}/{nameId}", Name = nameof(GetSpecificBookmarksTitle))]
    public IActionResult GetSpecificBookmarksTitle(int userId, string titleId)
    {
        var bookmarksTitle = _dataService.GetSpecificBookmarksTitle(userId, titleId);
        if (bookmarksTitle == null)
        {
            return NotFound();
        }

        return Ok(CreateBookmarksTitleModel(bookmarksTitle));
    }

    [HttpPost]
    public IActionResult CreateBookmarksTitle(CreateBookmarksTitleModel model)
    {
        var bookmarksTitle = new BookmarksTitle
        {
            UserId = model.UserId,
            TitleId = model.TitleId
        };

        _dataService.CreateBookmarksTitle(bookmarksTitle);

        var bookmarksTitleUri = Url.Link("GetBookmarksTitle", new { userId = bookmarksTitle.UserId, nameId = bookmarksTitle.TitleId });

        return Created(bookmarksTitleUri, bookmarksTitle);
    }



    private BookmarksTitleModel CreateBookmarksTitleModel(BookmarksTitle bookmarksTitle)
    {
        return new BookmarksTitleModel
        {
            Url = GetUrl(nameof(GetSpecificBookmarksTitle), new { bookmarksTitle.UserId, bookmarksTitle.TitleId }),
            TitleId = bookmarksTitle.TitleId,
            UserId = bookmarksTitle.UserId
        };
    }
}