using DataLayer;
using Microsoft.AspNetCore.Http.HttpResults;
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
        if (!string.IsNullOrEmpty(name))
        {
            result = _dataService.GetCategoriesByName(name)
                .Select(CreateCategoryModel);
        }
        else
        {
            result = _dataService.GetCategories()
                .Select(CreateCategoryModel);
        }
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

        var categoryUri = Url.Link("GetCategory", new { id = category.Id });

        return Created(categoryUri, category);
    }

    [HttpPut("{id}", Name = nameof(UpdateCategory))]
    public IActionResult UpdateCategory(CategoryModel model, int? id)
    {
        var existCategory = _dataService.GetCategory(id.Value);
        Console.WriteLine(id.Value);
        //checks for nullvalue
        if (existCategory != null)
        {
            //pre-updates categoryname (if submitted)
            if (model.Name != null)
            {
                existCategory.CategoryName = model.Name;
            }
            //pre-updates desciprion (if submitted)
            if (model.Description != null)
            {
                existCategory.Description = model.Description;
            }

            _dataService.UpdateCategory(existCategory.Id, existCategory.CategoryName, existCategory.Description);
            return Ok(existCategory);
        }else
        {
            return NotFound();
        }
        
    }

    [HttpDelete("{id}", Name = nameof(DeleteData))]
    public IActionResult DeleteData(int id)
    {
        Console.WriteLine("DeleteData: "+id);
        var existCategory = _dataService.GetCategory(id);

        //checks for null value
        if (existCategory == null)
        {
            return NotFound();
        }

        //deletes category
        _dataService.DeleteCategory(id);
        return Ok();
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
