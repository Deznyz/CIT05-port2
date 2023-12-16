using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        try
        {
            // Vi henter brugeren ud fra brugernavn
            var user = _dataService.GetUserByUsername(model.UserName);

            // Verificerer om adgangskoden er korrekt
            bool isPasswordCorrect = VerifyPassword(user, model.Password);

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
        catch (KeyNotFoundException)
        {
            // Hvis brugeren ikke findes, sender vi en "HTTP 404 Not Found" retur
            return NotFound("Brugeren blev ikke fundet");
        }
    }


    /*
     * GenerateJwtToken og VerifyPassword bør ikke være i AuthControlleren, da det er godt praksis at flytte "hjælpemetoder" til seperate klasser.
     * Man kunne f.eks. lave en klasse der hedder JwtTokenGenerator, der sørger for oprette en token,
     * og man kunne f.eks. lave en klasse der hedder PasswordHasherService, som sørger for at hashe og verificere adgangskoder
     */

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


    public bool VerifyPassword(Users user, string enteredPassword)
    {
        var hasher = new PasswordHasher<Users>();
        var result = hasher.VerifyHashedPassword(user, user.Password, enteredPassword);

        return result == PasswordVerificationResult.Success;
    }


}