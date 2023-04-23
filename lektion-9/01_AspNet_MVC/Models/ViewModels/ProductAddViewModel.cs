namespace _01_AspNet_MVC.Models.ViewModels
{
    public class ProductAddViewModel
    {
        public ProductAddFormModel Form { get; set; } = new ProductAddFormModel();
        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; } = new List<ProductCategoryModel>();
        
    }
}
