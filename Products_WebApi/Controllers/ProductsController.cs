using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Products_WebApi.DTO.Requests;
using Products_WebApi.DTO.Responses;
using Products_WebApi.Entity;

namespace Products_WebApi.Controllers;

[ApiController]
[Route("controller")]
public class ProductsController : ControllerBase
{
    static string jsonFile = System.IO.File.ReadAllText("DataBaseJson/products.json");
    private List<Product>? _products = JsonSerializer.Deserialize<List<Product>>(jsonFile);

    [HttpGet("all")]
    public IActionResult GetAllItems()
    {
        if(_products==null)
            return BadRequest();
            
        var products = _products;
        return Ok(products);
    }

    [HttpGet("id")]
    public IActionResult GetById([FromQuery]int id)
    {
        if (_products==null)
            return BadRequest();
        
        if(id <= 0 || id > _products.Count)
            return BadRequest(404);
            
        var product = _products.Where(p => p.Id == id).FirstOrDefault();
        return Ok(product);
    }

    [HttpPost("create")]
    public IActionResult CreateProduct([FromBody] CreateProductRequest request)
    {
        var product = new Product
        {
            Id = _products.Count + 1,
            Name = request.Name,
            Category = request.Category,
            Price = request.Price,
            CreatedAt = DateTime.Now
        };

        _products.Add(product);

        var response = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name
        };
        
        return Ok(product);
    }

    public IActionResult UpdateProduct([FromBody] UpdateProductRequest request,  [FromQuery]int id)
    {
         
    }
}