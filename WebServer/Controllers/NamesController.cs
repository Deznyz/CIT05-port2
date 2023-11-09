//using DataLayer;
//using DataLayer.Models;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using WebServer.Models;

//namespace WebServer.Controllers;

//[Route("api/names")]
//[ApiController]
//public class NamesController : BaseController
//{
//    private readonly IDataService _dataService;

//    public NamesController(IDataService dataService, LinkGenerator linkGenerator)
//        : base(linkGenerator)
//    {
//        _dataService = dataService;

//    }

//    [HttpGet(Name = nameof(GetNames))]
//    public IActionResult GetNames(int page = 0, int pageSize = 10)
//    {


//        (var Names, var total) = _dataService.GetNames(page, pageSize);

//        var items = Names.Select(CreateNamesModel);

//        var result = Paging(items, total, page, pageSize, nameof(GetNames));

//        return Ok(result);

//    }

//    [HttpGet("{Id}", Name = nameof(GetName))]
//    public IActionResult GetName(string nameId)
//    {
//        var Name = _dataService.GetName(nameId);
//        if (Name == null)
//        {
//            return NotFound();
//        }

//        return Ok(CreateNamesModel(Name));
//    }

//    private NamesModel CreateNamesModel(Names names)
//    {
//        return new NamesModel
//        {
//            Url = GetUrl(nameof(GetNames), new { names.NameId }),
//            NameId = names.NameId,
//            Name = names.Name,
//            BirthYear = names.BirthYear,
//            DeathYear = names.DeathYear,
//            AvgNameRating = names.AvgNameRating
//        };
//    }





//}