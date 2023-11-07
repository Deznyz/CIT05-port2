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

    // TODO: GET


    // POST
    [HttpPost]
    public IActionResult CreateUser(CreateUsersModel model)
    {
        var user = new Users
        {
            UserName = model.UserName,
            Password = model.Password
        };

        _dataService.CreateUsers(user);

        return Ok(user);
    }

    // TODO: PUT

    // TODO: DELETE



    /*
    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }
    */

}