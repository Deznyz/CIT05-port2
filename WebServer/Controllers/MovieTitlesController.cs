using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpGet(Name = nameof(GetMovieTitles))]
    public IActionResult GetMovieTitles(int page = 0, int pageSize = 10)
    {


        (var movieTitles, var total) = _dataService.GetMovieTitles(page, pageSize);

        var items = movieTitles.Select(CreateMovieTitleModel);

        var result = Paging(items, total, page, pageSize, nameof(GetMovieTitles));

        return Ok(result);

    }

    [HttpGet("{Id}", Name = nameof(GetMovieTitle))]
    public IActionResult GetMovieTitle(string movieTitleId)
    {
        var movieTitle = _dataService.GetMovieTitle(movieTitleId);
        if (movieTitle == null)
        {
            return NotFound();
        }

        return Ok(CreateMovieTitleModel(movieTitle));
    }

    private MovieTitlesModel CreateMovieTitleModel(MovieTitles movieTitle)
    {
        return new MovieTitlesModel
        {
            Url = GetUrl(nameof(GetMovieTitle), new { movieTitle.TitleId }),
            TitleId = movieTitle.TitleId,
            PrimaryTitle = movieTitle.PrimaryTitle,
            OriginalTitle = movieTitle.OriginalTitle,
            IsAdult = movieTitle.IsAdult,
            StartYear = movieTitle.StartYear,
            EndYear = movieTitle.EndYear,
            RuntimeMinutes = movieTitle.RuntimeMinutes
        };
    }



    //private string? GetUrl(string name, object values)
    //{
    //    return _linkGenerator.GetUriByName(HttpContext, name, values);
    //}

}