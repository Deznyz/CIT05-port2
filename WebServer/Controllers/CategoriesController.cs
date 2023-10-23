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

        // Generate the URI for the newly created category.
        var categoryUri = Url.Link("GetCategory", new { id = category.Id });

        // Return a Created response with the generated URI.
        return Created(categoryUri, category);
    }

    [HttpPut("{id}")]
    public IActionResult PutData(Category model)
    {
        var existingCategory = _dataService.GetCategory(model.Id);

        if (existingCategory != null)
        {
            if (model.CategoryName != null)
            {
                existingCategory.CategoryName = model.CategoryName;
            }

            if (model.Description != null)
            {
                existingCategory.Description = model.Description;
            }
            Console.WriteLine("test");

            _dataService.UpdateCategory(existingCategory.Id, existingCategory.CategoryName, existingCategory.Description);

            Console.WriteLine("test2");

            var categoryUri = Url.Link("GetCategory", new { id = existingCategory.Id });

            Console.WriteLine("test3");
            return Ok(existingCategory);
    }else
        {
            Console.WriteLine("test-notfound");
            return NotFound();
}

        
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
