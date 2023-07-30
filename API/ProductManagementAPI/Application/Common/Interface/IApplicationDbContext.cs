using API.ProductManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace API.ProductManagementAPI.Application.Common.Interface;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Subcategory> Subcategories { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}