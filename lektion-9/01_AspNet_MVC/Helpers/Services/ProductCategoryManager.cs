using _01_AspNet_MVC.Helpers.Repositories;
using _01_AspNet_MVC.Models;
using _01_AspNet_MVC.Models.Entities;

namespace _01_AspNet_MVC.Helpers.Services
{
    public class ProductCategoryManager
    {
        private readonly ProductCategoryRepo _categoryRepo;

        public ProductCategoryManager(ProductCategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<ProductCategoryEntity> GetOrCreateAsync(ProductCategoryModel model)
        {
            var categoryEntity = await _categoryRepo.GetAsync(x => x.Id == model.Value);
            categoryEntity ??= await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = model.Name });
            return categoryEntity;
        }

        public async Task<IEnumerable<ProductCategoryModel>> GetCategoriesAsync()
        {
            var items = await _categoryRepo.GetAllAsync();
            var categories = new List<ProductCategoryModel>();

            foreach (var item in items)
                categories.Add(new ProductCategoryModel { Name = item.CategoryName, Value = item.Id });

            return categories;
        }
    }
}
