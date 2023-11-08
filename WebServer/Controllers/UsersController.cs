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
    private readonly IConfiguration _configuration;

    public UsersController(IDataService dataService, LinkGenerator linkGenerator, IConfiguration configuration)
        : base(linkGenerator)
    {
        _dataService = dataService;
        _configuration = configuration;
    }

    // TODO: GET


    // POST
    [HttpPost]
    public IActionResult CreateUser(CreateUsersModel model)
    {
        // todo: man kunne med fordel bruge PasswordHasher, men det vil kræve at man udvider antal tilladte karakter i db
        // var hasher = new PasswordHasher<Users>();

        var user = new Users
        {
            UserName = model.UserName,
            Password = model.Password
        };

        _dataService.CreateUsers(user);

        return Ok(new { user.UserId, user.UserName });
    }

    // todo: Vi bør overveje at oprette en Auth Controller i stedet for den er i Users Controller
    // POST
    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var user = _dataService.GetUserByUsername(model.UserName);

        if (user == null)
        {
            return Unauthorized("Forkerte brugeroplysninger");
        }

        bool isPasswordCorrect = _dataService.VerifyPassword(user, model.Password);

        if (isPasswordCorrect)
        {
            var token = GenerateJwtToken(user.UserName);
            return Ok(new {Token = token});
        }
        else
        {
            return Unauthorized("Forkerte brugeroplysninger");
        }
    }

    private string GenerateJwtToken(string userName)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    /*
    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }
    */

}