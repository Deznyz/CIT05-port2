//using DataLayer;
//using DataLayer.Models;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using WebServer.Models;

//namespace WebServer.Controllers;

//[Route("api/movieratings")]
//[ApiController]
//public class MovieRatingsController : BaseController
//{
//    private readonly IDataService _dataService;

//    public MovieRatingsController(IDataService dataService, LinkGenerator linkGenerator)
//        : base(linkGenerator)
//    {
//        _dataService = dataService;

//    }

//    [HttpGet(Name = nameof(GetMovieRatings))]
//    public IActionResult GetMovieRatings(int page = 0, int pageSize = 10)
//    {


//        (var movieRating, var total) = _dataService.GetMovieRating(page, pageSize);

//        var items = movieRating.Select(CreateMovieRatingsModel);

//        var result = Paging(items, total, page, pageSize, nameof(GetMovieRatings));

//        return Ok(result);

//    }

//    [HttpGet("{titleRatingsId}", Name = nameof(GetMovieRating))]
//    public IActionResult GetMovieRating(string titleRatingsId)
//    {
//        var movieRating = _dataService.GetMovieRating(titleRatingsId);
//        if (movieRating == null)
//        {
//            return NotFound();
//        }

//        return Ok(CreateMovieRatingsModel(movieRating));
//    }

//    private MovieRatingsModel CreateMovieRatingsModel(MovieRatings movierating)
//    {
//        return new MovieRatingsModel
//        {
//            Url = GetUrl(nameof(GetMovieRating), new { movierating.TitleId }),
//            TitleId = movierating.TitleId,
//            AverageRating = movierating.AverageRating,
//            NumVotes = movierating.NumVotes
//        };
//    }

//    //private string? GetUrl(string name, object values)
//    //{
//    //    return _linkGenerator.GetUriByName(HttpContext, name, values);
//    //}

//}