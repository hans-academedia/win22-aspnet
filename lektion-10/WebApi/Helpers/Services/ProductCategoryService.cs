using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly ProductCategoryRepo _productCategoryRepo;

        public ProductCategoryService(ProductCategoryRepo productCategoryRepo)
        {
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<ProductCategory> CreateProductCategoryAsync(string categoryName)
        {
            var entity = new ProductCategoryEntity { CategoryName = categoryName };
            var result = await _productCategoryRepo.AddAsync(entity);
            return result;
        }


        public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategorySchema schema)
        {
            var result = await _productCategoryRepo.AddAsync(schema);
            return result;
        }

        public async Task<ProductCategory> GetProductCategoryAsync(int id)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.Id == id);
            return result;
        }

        public async Task<ProductCategory> GetProductCategoryAsync(string categoryName)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == categoryName);
            return result;
        }

        public async Task<ProductCategory> GetProductCategoryAsync(ProductCategorySchema schema)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == schema.CategoryName);
            return result;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            var result = await _productCategoryRepo.GetAllAsync();
            var list = new List<ProductCategory>();
            foreach (var category in result)
                list.Add(category);

            return list;
        }



    }
}
