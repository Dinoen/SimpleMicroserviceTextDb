using Microsoft.EntityFrameworkCore;
using SimpleMicroservice.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product1", Price = 10.0m },
            new Product { Id = 2, Name = "Product2", Price = 20.0m },
            new Product { Id = 3, Name = "Product3", Price = 30.0m }
        );

        modelBuilder.Entity<Entry>().HasData(
            new Entry { Id = 1, Data = "datablock1" },
            new Entry { Id = 2, Data = "datablock2" },
            new Entry { Id = 3, Data = "datablock3" }
        );
    }
}
