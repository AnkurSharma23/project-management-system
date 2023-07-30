using System.ComponentModel.DataAnnotations;

namespace API.ProductManagementAPI.Data;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public int SubcategoryId { get; set; }
    public Category Category { get; set; }
    public Subcategory Subcategory { get; set; }
}
