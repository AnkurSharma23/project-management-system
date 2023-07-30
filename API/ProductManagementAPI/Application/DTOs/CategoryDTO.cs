namespace API.ProductManagementAPI.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<SubcategoryDTO> Subcategories { get; set; }
}