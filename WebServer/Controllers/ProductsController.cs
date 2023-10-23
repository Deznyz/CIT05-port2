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
    [HttpGet]
    public IActionResult GetProducts(int id)
    {
        IEnumerable<ProductModel> result = null;
            
            result = _dataService.GetProduct(id)
                .Select(CreateProductModel);

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
