using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/episodebelongsto")]
[ApiController]
public class EpisodeBelongsToController : BaseController
{
    private readonly IDataService _dataService;

    public EpisodeBelongsToController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetEpisodeBelongsTos))]
    public IActionResult GetEpisodeBelongsTos(int page = 0, int pageSize = 10)
    {
        //var result = _dataService.GetAliases().Select(CreateAliasesModel);
        //return Ok( result);

        (var episodeBelongsTo, var total) = _dataService.GetEpisodeBelongsTos(page, pageSize);

        var items = episodeBelongsTo.Select(CreateEpisodeBelongsToModel);

        var result = Paging(items, total, page, pageSize, nameof(GetEpisodeBelongsTos));

        return Ok(result);

    }

    [HttpGet("{parentTvShowTitleId}")]
    public IActionResult GetEpisodeBelongsTosByParentTvShowTitleId(string parentTvShowTitleId, int page, int pageSize)
    {
        //var result = _dataService.GetAliases(titleId, 0, 10).Select(CreateAliasesModel);
        //return Ok(result);

        (var episodeBelongsTo, var total) = _dataService.GetEpisodeBelongsTosByParentTvShowTitleId(parentTvShowTitleId, page, pageSize);

        var items = episodeBelongsTo.Select(CreateEpisodeBelongsToModel);

        var result = Paging(items, total, page, pageSize, nameof(GetEpisodeBelongsTos));

        return Ok(result);

    }

    [HttpGet("{episodeTitleId}", Name = nameof(GetEpisodeBelongsToParentTvShowId))]
    public IActionResult GetEpisodeBelongsToParentTvShowId(string episodeTitleId)
    {
        var episodeBelongsTo = _dataService.GetEpisodeBelongsToParentTvShowId(episodeTitleId);
        if (episodeBelongsTo == null)
        {
            return NotFound();
        }

        return Ok(CreateEpisodeBelongsToModel(episodeBelongsTo));
    }

    [HttpGet("{episodeTitleId}/{parentTvShowTitleId}", Name = nameof(GetEpisodeBelongsTo))]
    public IActionResult GetEpisodeBelongsTo(string episodeTitleId, string parentTvShowTitleId)
    {
        var episodeBelongsTo = _dataService.GetEpisodeBelongsTo(episodeTitleId, parentTvShowTitleId);
        if (episodeBelongsTo == null)
        {
            return NotFound();
        }

        return Ok(CreateEpisodeBelongsToModel(episodeBelongsTo));
    }

    [HttpPost]
    public IActionResult CreateEpisodeBelongsTo(CreateEpisodeBelongsToModel model)
    {
        var episodeBelongsTo = new EpisodeBelongsTo
        {
            EpisodeTitleId = model.EpisodeTitleId,
            ParentTvShowTitleId = model.ParentTvShowTitleId,
            SeasonNumber = model.SeasonNumber,
            EpisodeNumber = model.EpisodeNumber
        };

        _dataService.CreateEpisodeBelongsTo(episodeBelongsTo);

        var episodeBelongsToUri = Url.Link("GetEpisodeBelongsTo", new { episodeTitleId = episodeBelongsTo.EpisodeTitleId, parentTvShowTitleId = episodeBelongsTo.ParentTvShowTitleId });

        return Created(episodeBelongsToUri, episodeBelongsTo);
    }



    private EpisodeBelongsToModel CreateEpisodeBelongsToModel(EpisodeBelongsTo episodeBelongsTo)
    {
        return new EpisodeBelongsToModel
        {
            Url = GetUrl(nameof(GetEpisodeBelongsTo), new { episodeBelongsTo.EpisodeTitleId, episodeBelongsTo.ParentTvShowTitleId }),
            EpisodeTitleId = episodeBelongsTo.EpisodeTitleId,
            ParentTvShowTitleId = episodeBelongsTo.ParentTvShowTitleId,
            SeasonNumber = episodeBelongsTo.SeasonNumber,
            EpisodeNumber = episodeBelongsTo.EpisodeNumber
        };
    }

}