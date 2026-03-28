using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<AppContext>(c =>
        {
            c.UseNpgsql("Host=localhost;Database=salary_db;Username=postgres;Password=Nik2006151984_");
        });
        return serviceCollection;
    }
}