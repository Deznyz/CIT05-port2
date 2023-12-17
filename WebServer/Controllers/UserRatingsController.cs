using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/userratings")]
[ApiController]
public class UserRatingsController : BaseController
{
    private readonly IDataService _dataService;

    public UserRatingsController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet]
    public IActionResult GetUserRatings(int page = 0, int pageSize = 10)
    {
        (var UserRatings, var total) = _dataService.GetUserRatings(page, pageSize);

        var items = UserRatings.Select(CreateUserRatingsModel);

        var result = Paging(items, total, page, pageSize, nameof(GetUserRatings));

        return Ok(result);

    }

    [HttpGet("{nameId}")]
    public IActionResult GetUserRatings(int userId, int page, int pageSize)
    {
        (var userRatings, var total) = _dataService.GetUserRatings(userId, page, pageSize);

        var items = userRatings.Select(CreateUserRatingsModel);

        var result = Paging(items, total, page, pageSize, nameof(GetUserRatings));

        return Ok(result);

    }

    [HttpGet("{userId}/{titleId}", Name = nameof(GetUserRatings))]
    public IActionResult GetUserRatings(int userId, string titleId)
    {
        var userRatings = _dataService.GetUserRatings(userId, titleId);
        if (userId == null)
        {
            return NotFound();
        }

        return Ok(CreateUserRatingsModel(userRatings));
    }

    [HttpPost]
    public IActionResult CreateUserRatings(CreateUserRatingsModel model)
    {
        var userRatings = new UserRatings
        {
            UserId = model.UserId,
            TitleId = model.TitleId
        };

        _dataService.CreateUserRatings(userRatings);

        var userRatingsUri = Url.Link("GetUserRatings", new { userId = userRatings.UserId, titleId = userRatings.TitleId });

        return Created(userRatingsUri, userRatings);
    }

    private UserRatingsModel CreateUserRatingsModel(UserRatings userRatings)
    {
        return new UserRatingsModel
        {
            Url = GetUrl(nameof(GetUserRatings), new { userRatings.UserId, userRatings.TitleId }),
            UserId = userRatings.UserId,
            TitleId = userRatings.TitleId,
        };
    }
}

