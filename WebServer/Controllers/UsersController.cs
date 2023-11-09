using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
            return Ok(new { 
                UserId = createdUser.UserId, 
                Username = createdUser.UserName });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }

    }

    /*
    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }
    */

}