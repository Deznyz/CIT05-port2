using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/nameworkedas")]
[ApiController]
public class NameWorkedAsController : BaseController
{
    private readonly IDataService _dataService;

    public NameWorkedAsController(IDataService dataService, LinkGenerator linkGenerator)
        : base(linkGenerator)
    {
        _dataService = dataService;

    }

    [HttpGet(Name = nameof(GetNameWorkedAs))]
        public IActionResult GetNameWorkedAs(int page = 0, int pageSize = 10)
        {
            (var nameWorkedAs, var total) = _dataService.GetNameWorkedAs(page, pageSize);

            var items =  nameWorkedAs.Select(CreateNameWorkedAsModel);

            var result = Paging(items, total, page, pageSize, nameof(GetNameWorkedAs));

            return Ok(result);

        }

        [HttpGet("{nameId}")]
        public IActionResult GetNameWorkedAs(string nameId, int page, int pageSize)
        {
            (var nameWorkedAs, var total) = _dataService.GetNameWorkedAs(nameId, page, pageSize);

            var items = nameWorkedAs.Select(CreateNameWorkedAsModel);

            var result = Paging(items, total, page, pageSize, nameof(GetNameWorkedAs));

            return Ok(result);

        }

        [HttpGet("{nameId}/{profession}", Name = nameof(GetNameWorkedAs))]
        public IActionResult GetNameWorkedAs(string nameId, string? profession)
        {
            var nameWorkedAs = _dataService.GetNameWorkedAs(nameId, profession);
            if (nameId == null)
            {
                return NotFound();
            }

            return Ok(CreateNameWorkedAsModel(nameWorkedAs));
        }

        [HttpPost]
        public IActionResult CreateNameWorkedAs(CreateNameWorkedAsModel model)
        {
            var nameWorkedAs = new NameWorkedAs
            {
                NameId = model.NameId,
                Profession = model.Profession
             };

            _dataService.CreateNameWorkedAs(nameWorkedAs);

            var nameWorkedAsUri = Url.Link("GetNameWorkedAs", new { nameId = nameWorkedAs.NameId, profession = nameWorkedAs.Profession});

            return Created(nameWorkedAsUri, nameWorkedAs);
        }

        private NameWorkedAsModel CreateNameWorkedAsModel(NameWorkedAs nameWorkedAs)
        {
            return new NameWorkedAsModel
            {
                Url = GetUrl(nameof(GetNameWorkedAs), new { nameWorkedAs.NameId, nameWorkedAs.Profession }),
                NameId = nameWorkedAs.NameId,
                Profession = nameWorkedAs.Profession,
            };
        }    
}

