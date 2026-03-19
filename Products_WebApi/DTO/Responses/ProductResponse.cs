namespace Products_WebApi.DTO.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
}