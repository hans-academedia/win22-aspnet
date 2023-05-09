using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class ProductRepo : Repo<ProductEntity>
    {
        private readonly DataContext _context;

        public ProductRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var entity = await _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(expression);
            if (entity != null)
                return entity!;

            return null!;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
        }
    }
}
