using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public CategoriesController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    public IActionResult GetCetagories(string? name = null)
    {
        IEnumerable<CategoryModel> result = null;
        
            result = _dataService.GetCategories()
                .Select(CreateCategoryModel);
        
        return Ok(result);
    }
    
    [HttpGet("{id}", Name = nameof(GetCategory))]
    public IActionResult GetCategory(int id)
    {
        var category = _dataService.GetCategory(id);
        if(category == null)
        {
            return NotFound();
        }

        return Ok(CreateCategoryModel(category));
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryModel model)
    {
        var category = new Category
        {
            CategoryName = model.Name,
            Description = model.Description
        };

        _dataService.CreateCategory(category);

        return Ok(category);
    }


    private CategoryModel CreateCategoryModel(Category category)
    {
        return new CategoryModel
        {
            //Url = $"http://localhost:5001/api/categories/{category.Id}",
            Url = GetUrl(nameof(GetCategory), new { category.Id }),
            Name = category.CategoryName,
            Description = category.Description
        };
    }

    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }
    
}
