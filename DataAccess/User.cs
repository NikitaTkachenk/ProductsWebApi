namespace DataAccess;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public bool isAdmin { get; set; } =  false;
    
    public ICollection<Product> Products { get; set; }
}