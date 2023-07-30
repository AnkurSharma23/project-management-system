namespace API.ProductManagementAPI.Data;

using System.ComponentModel.DataAnnotations;
using API.ProductManagementAPI.Data;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Subcategory> Subcategories { get; set; }
}
