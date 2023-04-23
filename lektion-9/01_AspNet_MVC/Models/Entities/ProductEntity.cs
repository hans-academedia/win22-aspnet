namespace _01_AspNet_MVC.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!; 
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategoryEntity Category { get; set; } = null!;
    }
}
