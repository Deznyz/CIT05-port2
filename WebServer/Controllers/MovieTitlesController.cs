using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/movietitles")]
[ApiController]
public class MovieTitlesController : BaseController
{
    private readonly IDataService _dataService;

    public MovieTitlesController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;
    }

    [HttpGet("searchtitle/{userId}/{title}")]
    public IActionResult SearchTitle(int userId, string title, int page = 0, int pageSize = 10)
    {

        (var searchTitleResult, var total) = _dataService.SearchTitle(userId, title, page, pageSize);
        return Ok(searchTitleResult);
    }

    [HttpGet("castrating/titleid/{movieId}")]
    public IActionResult GetCastRatingsMovieId(string movieId, int page = 0, int pageSize = 10)
    {

        (var castRatings, var total) = _dataService.GetCastRatingsMovieId(movieId, page, pageSize);
        return Ok(castRatings);
    }

    [HttpGet("castrating/movietitle/{movieTitle}")]
    public IActionResult GetCastRatingsMovieTitles(string movieTitle, int page = 0, int pageSize = 10)
    {

        (var castRatings, var total) = _dataService.GetCastRatingsMovieTitles(movieTitle, page, pageSize);
        return Ok(castRatings);
    }


    [HttpGet(Name = nameof(GetMovieTitles))]
    public IActionResult GetMovieTitles(int page = 0, int pageSize = 10) { 

        (var movieTitles, var total) = _dataService.GetMovieTitles(page, pageSize);

        var items = movieTitles.Select(CreateMovieTitleModel);

        var result = Paging(items, total, page, pageSize, nameof(GetMovieTitles));

        return Ok(result);

    }

    [HttpGet("{movieTitleId}", Name = nameof(GetMovieTitle))]
    public IActionResult GetMovieTitle(string movieTitleId)
    {
        var movieTitle = _dataService.GetMovieTitle(movieTitleId);
        if (movieTitle == null)
        {
            return NotFound();
        }

        return Ok(movieTitle);
    }


    private MovieTitlesModel CreateMovieTitleModel(MovieTitles movieTitle)
    {
        return new MovieTitlesModel
        {
            Url = GetUrl(nameof(GetMovieTitle), new { movieTitle.TitleId }),
            TitleId = movieTitle.TitleId,
            TitleType = movieTitle.TitleType,
            PrimaryTitle = movieTitle.PrimaryTitle,
            OriginalTitle = movieTitle.OriginalTitle,
            IsAdult = movieTitle.IsAdult,
            StartYear = movieTitle.StartYear,
            EndYear = movieTitle.EndYear,
            RuntimeMinutes = movieTitle.RuntimeMinutes
        };
    }

}