using Microsoft.AspNetCore.Mvc;
using DataAccess;

namespace Products_WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly ProductRepository _repository;
    
    public ProductController(ProductRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet("get")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("add")]
    public async Task<IActionResult> Add()
    {
        await _repository.CreateWithProductsAsync();
        return Ok();
    }
}