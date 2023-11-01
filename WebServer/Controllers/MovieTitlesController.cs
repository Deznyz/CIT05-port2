using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/movietitles")]
[ApiController]
public class MovieTitlesController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public MovieTitlesController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private MovieTitlesModel CreateMovieTitlesModel(MovieTitles movieTitles)
    //{
    //    return new MovieTitlesModel
    //    {
    //        Url = GetUrl(nameof(GetMovieTitles), new { movieTitles.TitleId}),
    //        TitleId = movieTitles.TitleId,
    //        TitleType = movieTitles.TitleType,
    //        PrimaryTitle = movieTitles.PrimaryTitle,
    //        OriginalTitle = movieTitles.OriginalTitle,
    //        IsAdult = movieTitles.IsAdult,
    //        StartYear = movieTitles.StartYear,
    //        EndYear = movieTitles.EndYear,
    //        RuntimeMinutes = movieTitles.RuntimeMinutes
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}