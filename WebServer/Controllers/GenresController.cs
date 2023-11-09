using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/genres")]
[ApiController]
public class GenresController : BaseController
    {
        private readonly IDataService _dataService;

    public GenresController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetGenres))]
    public IActionResult GetGenres(int page = 0, int pageSize = 10)
    {


        (var genres, var total) = _dataService.GetGenres(page, pageSize);

        var items = genres.Select(CreateGenresModel);

        var result = Paging(items, total, page, pageSize, nameof(GetGenres));

        return Ok(result);

    }

    [HttpGet("{titleId}")]
    public IActionResult GetGenres(string titleId, int page, int pageSize)
    {

        (var genres, var total) = _dataService.GetGenres(titleId, page, pageSize);

        var items = genres.Select(CreateGenresModel);

        var result = Paging(items, total, page, pageSize, nameof(GetGenres));

        return Ok(result);

    }

    [HttpGet("{titleId}/{genres}", Name = nameof(GetGenre))]
    public IActionResult GetGenre(string titleId, string genreData)
    {
        var genre = _dataService.GetGenre(titleId, genreData);
        if (genre == null)
        {
            return NotFound();
        }

        return Ok(CreateGenresModel(genre));
    }

    [HttpPost]
    public IActionResult CreateGenre(CreateGenresModel model)
    {
        var genre = new Genres
        {
            TitleId = model.TitleId,
            Genre = model.Genre
        };

        _dataService.CreateGenres(genre);

        var genreUri = Url.Link("GetGenre", new { titleId = genre.TitleId, genre = genre.Genre });

        return Created(genreUri, genre);
    }

    private GenresModel CreateGenresModel(Genres genres)
    {
        return new GenresModel
        {
            Url = GetUrl(nameof(GetGenre), new { genres.TitleId, genres.Genre }),
            TitleId = genres.TitleId,
            Genre = genres.Genre
        };
    }

    //private string? GetUrl(string name, object values)
    //{
    //    return _linkGenerator.GetUriByName(HttpContext, name, values);
    //}

}