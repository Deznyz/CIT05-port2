using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/episodebelongsto")]
[ApiController]
public class EpisodeBelongsToController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public EpisodeBelongsToController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }



    //private EpisodeBelongsToModel CreateEpisodeBelongsToModel(EpisodeBelongsTo episodeBelongsTo)
    //{
    //    return new EpisodeBelongsToModel
    //    {
    //        Url = GetUrl(nameof(GetEpisodeBelongsTo), new { episodeBelongsTo.EpisodeTitleId, episodeBelongsTo.ParentTvShowTitleId }),
    //        EpisodeTitleId = episodeBelongsTo.EpisodeTitleId,
    //        ParentTvShowTitleId = episodeBelongsTo.ParentTvShowTitleId,
    //        SeasonNumber = episodeBelongsTo.SeasonNumber,
    //        EpisodeNumber = episodeBelongsTo.EpisodeNumber
    //    };
    //}

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}