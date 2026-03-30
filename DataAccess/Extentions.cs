using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extentions
{
    public static void AddDataBase(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddDbContext<ProductContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=Products;Username=postgres;Password=Nik2006151984_;");
        });
    }

}