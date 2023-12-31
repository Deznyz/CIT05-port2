using DataLayer;
using DataLayer.Models;
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
        public IActionResult GetNameWorkedAs(string nameId, int page=0, int pageSize=10)
        {
            (var nameWorkedAs, var total) = _dataService.GetNameWorkedAsByNameId(nameId, page, pageSize);

            var items = nameWorkedAs.Select(CreateNameWorkedAsModel);

            var result = Paging(items, total, page, pageSize, nameof(GetNameWorkedAs));

            return Ok(result);

        }

        [HttpGet("{nameId}/{profession}", Name = nameof(GetSpecificNameWorkedAs))]
        public IActionResult GetSpecificNameWorkedAs(string nameId, string? profession)
        {
            var nameWorkedAs = _dataService.GetSpecificNameWorkedAs(nameId, profession);
            if (nameId == null)
            {
                return NotFound();
            }

            return Ok(CreateNameWorkedAsModel(nameWorkedAs));
        }



    [HttpPut("update/{nameId}/{profession}", Name = nameof(UpdateNameWorkedAs))]
    public IActionResult UpdateNameWorkedAs(string nameId, string profession, CreateNameWorkedAsModel model)
    {
        var existNameWorkedAs = _dataService.GetSpecificNameWorkedAs(nameId, profession);

        if (existNameWorkedAs != null)
        {
            var updateNameWorkedAs = new NameWorkedAs
            {
                NameId = model.NameId,
                Profession = model.Profession
            };

            _dataService.UpdateNameWorkedAs(nameId, updateNameWorkedAs);
            return Ok(existNameWorkedAs);
        }
        else
        {
            return NotFound();
        }
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
                Url = GetUrl(nameof(GetSpecificNameWorkedAs), new { nameWorkedAs.NameId, nameWorkedAs.Profession }),
                NameId = nameWorkedAs.NameId,
                Profession = nameWorkedAs.Profession,
            };
        }    
}

