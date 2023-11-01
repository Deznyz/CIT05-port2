using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/genres")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public GenresController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private GenresModel CreateGenresModel(Genres genres)
    //{
    //    return new GenresModel
    //    {
    //        Url = GetUrl(nameof(GetGenres), new { genres.TitleId, genres.Genre }),
    //        TitleId = genres.TitleId,
    //        Genre = genres.Genre
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}