namespace API.ProductManagementAPI.DTOs
{
    public class SubcategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public List<ProductDTO> Products { get; set; }
    }
}