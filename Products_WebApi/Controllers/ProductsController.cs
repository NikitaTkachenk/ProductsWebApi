using Microsoft.AspNetCore.Mvc;
using Products_WebApi.DTO.Requests;
using Products_WebApi.DTO.Responses;
using Products_WebApi.Entity;
using FluentValidation;
using Products_WebApi.ProductValidators;
using Products_WebApi.DataBaseJson;

namespace Products_WebApi.Controllers;

[ApiController]
[Route("controller")]
public class ProductsController(IValidator<CreateProductRequest> createValidator, IValidator<UpdateProductRequest> updateValidator) : ControllerBase
{
    [HttpGet("all")]
    public IActionResult GetAllItems()
    {
        if(Data._products is null)
            return BadRequest();
            
        var products = Data._products;
        return Ok(products);
    }

    [HttpGet("id")]
    public IActionResult GetById([FromQuery]int id)
    {
        if (Data._products==null)
            return BadRequest();
        
        if(id <= 0 || id > Data._products.Count)
            return BadRequest(404);
            
        var product = Data._products.FirstOrDefault(p => p.Id == id);
        return Ok(product);
    }

    [HttpPost("create")]
    public IActionResult CreateProduct([FromBody] CreateProductRequest request)
    {
        createValidator.ValidateAndThrow(request);

        if(Data._products is null)
            return BadRequest();
        
        var product = new Product
        {
            Id = Data._products.Count + 1,
            Name = request.Name,
            Category = request.Category,
            Price = request.Price,
            CreatedAt = DateTime.Now
        };

        Data._products.Add(product);

        var response = new ProductResponse
        {
            Id = product.Id,
            Name = product.Name
        };
        
        return Ok(product);
    }

    [HttpPost("update")]
    public IActionResult UpdateProductById([FromBody] UpdateProductRequest request,  [FromQuery]int id)
    {
        updateValidator.ValidateAndThrow(request);

        if(Data._products is null)
            return BadRequest();

        var product = Data._products.FirstOrDefault(p => p.Id == id);

        if(product is not null)
        {
            product.Name = request.Name;
            product.Category = request.Category;
            product.Price = request.Price;
        }

        return Ok(product);
    }

    [HttpDelete("delete")]
    public IActionResult DeleteProductById([FromQuery] int id)
    {
        if(Data._products is null)
            return BadRequest();

        var product = Data._products.FirstOrDefault(p => p.Id == id);

        if(product is null)
            return BadRequest();

        Data._products.Remove(product);

        return Ok(product);
    }
}