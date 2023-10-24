using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly LinkGenerator _linkGenerator;

    public ProductsController(DataService dataService, LinkGenerator linkGenerator)
    {
        _dataService = dataService;
        _linkGenerator = linkGenerator;
    }

    [HttpGet("category/{categoryId}")]
    public IActionResult GetProductsByCategory(int categoryId)
    {
        var category = _dataService.GetCategory(categoryId);
        var products = _dataService.GetProductByCategory(categoryId);

        if (category == null)
        {
            return NotFound(products);
        }

        

        var result = products.Select(CreateProductModel);

        return Ok(result);
    }



    [HttpGet("{id}", Name = nameof(GetProduct))]
    public IActionResult GetProduct(int id)
    {
        var product = _dataService.GetProduct(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(CreateProductModel(product));
    }

    [HttpGet]
    public IActionResult GetProducts(string? name = null)
    {
        IEnumerable<ProductModel> result = null;

        if (!string.IsNullOrEmpty(name))
        {
            result = _dataService.GetProductByName(name).Select(CreateProductModel);

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        else
        {
            result = _dataService.GetProducts().Select(CreateProductModel);
            return Ok(result);
        }
    }


    private ProductModel? CreateProductModel(ProductWithCategoryName product)
    {
        return new ProductModel
        {
            //Url = $"http://localhost:5001/api/products/{product.Id}",
            Url = GetUrl(nameof(GetProduct), new { product.Id }),
            Name = product.Name,
            CategoryName = product.CategoryName
        };
    }


    private string? GetUrl(string name, object values)
    {
        return _linkGenerator.GetUriByName(HttpContext, name, values);
    }

}
