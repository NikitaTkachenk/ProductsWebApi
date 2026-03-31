using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ProductRepository(ProductContext productContext) 
{
    // Создание информации в БД.
    public async Task CreateOnlyAsync()
    {
        await productContext.Users.AddAsync(new User
        {
            Name = "Nikita"
        });
        
        await productContext.SaveChangesAsync();
    }
    
    public async Task CreateWithProductsAsync()
    {
        await productContext.Users.AddAsync(new User
        {
            Name = "Nikita",
            Products = new List<Product>
            {
                new Product
                {
                    Name = "Guitar MX-5"
                }
            }
        });
        
        await productContext.SaveChangesAsync();
    }
    
    // Получение информации в БД.
    public async Task<List<Product>> GetAllAsync()
    {
        return await productContext.Products.ToListAsync();
    }
    
    public async Task<List<string>> GetAllNamesAsync()
    {
        return await productContext.Products.Select(p => p.Name).ToListAsync();
    }

    public async Task<Product> GetByName()
    {
        // AsNoTracking() - отключает отслеживание ЕФ коре для простоо считывания базы.
        return await productContext.Products.Where(p => p.Name == "Guitar MX-5").AsNoTracking().FirstOrDefaultAsync();
    }
    
    // Типу join, об'єднати таблицю Користувачі та продукти.
    public async Task<List<Product>> GetUserWithProductsAsync()
    {
        // Include - Росмотреть поподробнее!!!
        return await productContext.Products.Include(p => p.User).ToListAsync();
    }
    
    // Обновление данных
    public async Task UpdateAsync()
    {
        // Рассмотреть ExecuteUpdateAsync() и для него же SetProperty()!!!
        var user = await productContext.Users.Where(p => p.Name == "Guitar MX-5").FirstOrDefaultAsync();
        user.Name = "Gogoman";
        
        productContext.Update(user);
        
        await productContext.SaveChangesAsync();
    }

    public async Task DeleteAsync()
    {
        // Рассмотреть также ExecuteDeleteAsync()!!!
        var user = await productContext.Users.Where(p => p.Name == "Guitar MX-5").FirstOrDefaultAsync();
        productContext.Remove(user);
        
        await productContext.SaveChangesAsync();
    }
}