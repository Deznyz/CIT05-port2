using DataLayer;
using DataLayer.Models;
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

    [HttpPut("{id}/{newPassword}")]
    public IActionResult UpdateUserPassword(int id, string password) { 
        _dataService.UpdateUserPassword(id, password);
        return Ok();
    }

   
    [HttpGet]
    public IActionResult GetUsers(int page = 0, int pageSize = 10)
    {
        (var users, var total) = _dataService.GetUsers(page, pageSize);

        var items = users.Select(CreateUsersModel);

        var result = Paging(items, total, page, pageSize, nameof(GetUsers));

        return Ok(result);

    }


    [HttpPost]
    public IActionResult CreateUser(CreateUsersModel model)
    {
        // todo: man kunne med fordel bruge PasswordHasher, men det vil kræve at man udvider antal tilladte karakter i db
        // i test-fasen kan vi dog udelade det helt
        // var hasher = new PasswordHasher<Users>();

        var user = new Users
        {
            UserName = model.UserName,
            Password = model.Password
        };

        try
        {
            var createdUser = _dataService.CreateUser(user);
            return Ok(new
            {
                UserId = createdUser.UserId,
                Username = createdUser.UserName
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }

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

    private UsersModel CreateUsersModel(Users users)
    {
        return new UsersModel
        {
            Url = GetUrl(nameof(GetUsers), new { users.UserId}),
            UserId = users.UserId,
            Password = users.Password
        };
    }
}

