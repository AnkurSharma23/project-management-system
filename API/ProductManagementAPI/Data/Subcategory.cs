namespace API.ProductManagementAPI.Data;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Subcategory
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Product> Products { get; set; }
}
