namespace _01_AspNet_MVC.Models.Entities
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();   
    }
}
