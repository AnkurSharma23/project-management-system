using API.ProductManagementAPI.Application.Common.Interface;
using API.ProductManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace API.ProductManagementAPI.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Apparel" },
            new Category { Id = 3, Name = "Footwear" }
        );

        modelBuilder.Entity<Subcategory>().HasData(
            new Subcategory { Id = 1, Name = "TV", CategoryId = 1 },
            new Subcategory { Id = 2, Name = "Mobile", CategoryId = 1 },
            new Subcategory { Id = 3, Name = "Refrigerator", CategoryId = 1 },
            new Subcategory { Id = 4, Name = "Men's Cloth", CategoryId = 2 },
            new Subcategory { Id = 5, Name = "Women's Cloth", CategoryId = 2 },
            new Subcategory { Id = 6, Name = "Men's Footwear", CategoryId = 3 },
            new Subcategory { Id = 7, Name = "Kid's Footwear", CategoryId = 3 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, ProductCode = "P001", Name = "Product 1", Quantity = 50, Price = 99.99m, 
                          Description = "Sample product 1", ImageUrl = "product1.jpg", CategoryId = 1, SubcategoryId = 1 },
            new Product { Id = 2, ProductCode = "P002", Name = "Product 2", Quantity = 25, Price = 49.99m, 
                           Description = "Sample product 2", ImageUrl = "product2.jpg", CategoryId = 2, SubcategoryId = 4 }
        );

    }
}