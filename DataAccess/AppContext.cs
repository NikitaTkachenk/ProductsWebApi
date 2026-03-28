using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class AppContext(DbContextOptions<AppContext> options) : DbContext(options)   // Создание контекста для роботи с ЕФ коре.
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);   // Для добавления сущьности.
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(140);
        base.OnModelCreating(modelBuilder);
    }
    
}