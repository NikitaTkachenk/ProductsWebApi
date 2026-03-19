namespace Products_WebApi.DTO.Requests;

public class UpdateProductRequest
{
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
}