namespace DataAccess;

public class Product
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public User User { get; set; }
}