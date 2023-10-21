//using DataLayer;
//using Microsoft.AspNetCore.Mvc;
//using WebServer.Models;

//namespace WebServer.Controllers;

//[Route("api/products")]
//[ApiController]
//public class ProductsController : ControllerBase
//{
//    private readonly DataService _dataService;
//    private readonly LinkGenerator _linkGenerator;

//    public ProductsController(DataService dataService, LinkGenerator linkGenerator)
//    {
//        _dataService = dataService;
//        _linkGenerator = linkGenerator;
//    }
//    [HttpGet("{id}", Name = nameof(GetProduct))]
//    public IActionResult GetProduct(int id)
//    {
//        var product = _dataService.GetProduct(id);
//        if (product == null)
//        {
//            return NotFound();
//        }

//        return Ok(CreateProductModel(product));
//    }
//    //Den vil gerne have ProductWithCategoryName af en eller anden grund i stedet for product
//    private object? CreateProductModel(ProductWithCategoryName product)
//    {
//        throw new NotImplementedException();
//    }

//    private ProductModel? CreateProductModel(Product product)
//    {
//        return new ProductModel
//        {
//            //Url = $"http://localhost:5001/api/products/{product.Id}",
//            Url = GetUrl(nameof(GetProduct), new { product.Id }),
//            Name = product.Name,
//            UnitPrice = product.UnitPrice
//        };
//    }

//    private string? GetUrl(string name, object values)
//    {
//        return _linkGenerator.GetUriByName(HttpContext, name, values);
//    }

//}
