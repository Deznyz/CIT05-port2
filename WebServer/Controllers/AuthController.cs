using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/login")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IDataService _dataService;
    private readonly IConfiguration _configuration;

    public AuthController(IDataService dataService, LinkGenerator linkGenerator, IConfiguration configuration)
        : base(linkGenerator)
    {
        _dataService = dataService;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Vi validerer modellen først - det er god stil at gøre det først
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Vi henter brugeren ud fra brugernavn
        var user = _dataService.GetUserByUsername(model.UserName);

        // Hvis brugeren ikke findes returnes unauthorized response
        if (user == null)
        {
            return Unauthorized("Forkerte brugeroplysninger");
        }

        // Verificerer om adgangskoden er korrekt
        bool isPasswordCorrect = _dataService.VerifyPassword(user, model.Password);

        if (isPasswordCorrect)
        {
            // Hvis password er ok, oprettes or returneres en jwt token
            var token = GenerateJwtToken(user.UserName);
            return Ok(new
            {
                UserId = user.UserId,
                Username = user.UserName,
                Token = token
            });
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

   
}