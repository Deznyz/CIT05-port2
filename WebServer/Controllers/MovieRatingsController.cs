using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/movieratings")]
[ApiController]
public class MovieRatingsController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public MovieRatingsController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private MovieRatingsModel CreateMovieRatingsModel(MovieRatings movieRatings)
    //{
    //    return new MovieRatingsModel
    //    {
    //        Url = GetUrl(nameof(GetMovieRatings), new { movieRatings.TitleId}),
    //        TitleId = movieRatings.TitleId,
    //        AverageRating = movieRatings.AverageRating,
    //        NumVotes = movieRatings.NumVotes
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}