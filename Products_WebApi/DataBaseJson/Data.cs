using System.Text.Json;
using Products_WebApi.Entity;

namespace Products_WebApi.DataBaseJson;

public class Data
{
    private static readonly string _jsonFile = System.IO.File.ReadAllText("DataBaseJson/products.json");
    public static List<Product>? _products = JsonSerializer.Deserialize<List<Product>>(_jsonFile);
}