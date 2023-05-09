using System.Linq.Expressions;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepo;

        public CategoryService(CategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Category> GetOrCreateAsync(CategoryEntity entity)
        {
            var _entity = await GetAsync(x => x.CategoryName == entity.CategoryName);
            _entity ??= await CreateAsync(entity);

            return _entity;
        }


        public async Task<Category> GetAsync(Expression<Func<CategoryEntity, bool>> expression)
        {
            var _entity = await _categoryRepo.GetAsync(expression);
            return _entity!;
        }

        public async Task<Category> CreateAsync(CategoryEntity entity)
        {
            var _entity = await _categoryRepo.AddAsync(entity);
            return _entity!;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var entities = await _categoryRepo.GetAllAsync();
            var _entities = new List<Category>();
            foreach (var entity in entities)
                _entities.Add(entity);

            return _entities;
        }
    }
}
