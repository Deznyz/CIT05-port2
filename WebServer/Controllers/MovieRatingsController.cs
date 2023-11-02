using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/movieratings")]
[ApiController]
public class MovieRatingsController : BaseController
{
    private readonly IDataService _dataService;

    public MovieRatingsController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetMovieRatings))]
    public IActionResult GetMovieRatings(int page = 0, int pageSize = 10)
    {


        (var movieRating, var total) = _dataService.GetMovieRatings(page, pageSize);

        var items = knownFor.Select(CreateMovieRatingsModel);

        var result = Paging(items, total, page, pageSize, nameof(GetMovieRatings));

        return Ok(result);

    }

    [HttpGet("{titleRatingsId}")]
    public IActionResult GetMovieRatings(string titleRatingsId, int page, int pageSize)
    {

        (var movieRating, var total) = _dataService.GetMovieRatings(titleRatingsId, page, pageSize);

        var items = movieRating.Select(CreateMovieRatingsModel);

        var result = Paging(items, total, page, pageSize, nameof(GetMovieRatings));

        return Ok(result);

    }

    [HttpPost]
    public IActionResult CreatemovieRating(CreatemovieRatingsModel model)
    {
        var movieRating = new MovieRatings();
        {
            TitleId = model.TitleId,
            NameId = model.NameId
        };

        _dataService.CreateMovieRating(movieRating);

        var movieRatingUri = Url.Link("GetMovierating", new { titleId = knownFor.TitleId, nameId = knownFor.NameId });

        return Created(movieRatingUri, movieRating);
    }

    private MovieRatingsModel CreateMovieRatingsModel(MovieRatings movierating)
    {
        return new MovieRatingsModel
        {
            Url = GetUrl(nameof(GetMovierating), new { movierating.TitleId, movierating.NameId }),
            TitleId = movierating.TitleId,
            NameId = movierating.NameId
        };
    }

    //private string? GetUrl(string name, object values)
    //{
    //    return _linkGenerator.GetUriByName(HttpContext, name, values);
    //}

}