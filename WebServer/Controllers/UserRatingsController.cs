using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/userratings")]
[ApiController]
public class UserRatingsController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public UserRatingsController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    private UserRatingsModel CreateUserRatingsModel(UserRatings userRatings)
    {
        return new UserRatingsModel
        {
            Url = GetUrl(nameof(GetUserRatings), new { userRatings.TitleId, userRatings.UserId }),
            TitleId = userRatings.TitleId,
            UserId = userRatings.UserId,
            UserRating = userRatings.UserRating
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}