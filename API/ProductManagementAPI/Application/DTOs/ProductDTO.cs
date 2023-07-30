namespace API.ProductManagementAPI.DTOs;

public class ProductDTO
{

    public int Id { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public int SubcategoryId { get; set; }
    public CategoryDTO Category { get; set; }
    public SubcategoryDTO Subcategory { get; set; }
}