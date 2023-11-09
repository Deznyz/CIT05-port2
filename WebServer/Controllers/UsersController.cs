using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : BaseController
{
    private readonly IDataService _dataService;

    public UsersController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetUsers))]
    public IActionResult GetUsers(int page = 0, int pageSize = 10)
    {
        (var users, var total) = _dataService.GetUsers(page, pageSize);

        var items = users.Select(CreateUsersModel);

        var result = Paging(items, total, page, pageSize, nameof(GetUsers));

        return Ok(result);

    }

    [HttpGet("{userId}")]
    public IActionResult GetUsers(int userId, int page, int pageSize)
    {
        (var users, var total) = _dataService.GetUsers(userId, page, pageSize);

        var items = users.Select(CreateUsersModel);

        var result = Paging(items, total, page, pageSize, nameof(GetUsers));

        return Ok(result);

    }

    [HttpGet("{userId}", Name = nameof(GetUsers))]
    public IActionResult GetUsers(int userId)
    {
        var users = _dataService.GetUsers(userId);
        if (userId == null)
        {
            return NotFound();
        }

        return Ok(CreateUsersModel(users));
    }


    [HttpPost]
    public IActionResult CreateUsers(CreateUsersModel model)
    {
        var users = new Users
        {
            UserId = model.UserId,
        };

        _dataService.CreateUsers(users);

        var usersUri = Url.Link("GetUsers", new { userId = users.UserId});

        return Created(usersUri, users);
    }

    private UsersModel CreateUsersModel(Users users)
    {
        return new UsersModel
        {
            Url = GetUrl(nameof(GetUsers), new { users.UserId}),
            UserId = users.UserId,
        };
    }
}
