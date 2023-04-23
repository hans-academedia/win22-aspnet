using _01_AspNet_MVC.Helpers.Repositories;
using _01_AspNet_MVC.Models;
using _01_AspNet_MVC.Models.Entities;

namespace _01_AspNet_MVC.Helpers.Services
{
    public class ProductManager
    {
        private readonly ProductCategoryManager _categoryManager;
        private readonly ProductRepo _productManager;

        public ProductManager(ProductCategoryManager categoryManager, ProductRepo productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }

        public async Task AddAsync(ProductAddFormModel form)
        {
            ProductEntity product = form;
            product.CategoryId = (await _categoryManager.GetOrCreateAsync(form.Category)).Id;

            await _productManager.AddAsync(product);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _productManager.GetAllAsync();
        }

    }
}
