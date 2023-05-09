using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class ProductRepository : Repo<ProductEntity>
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
        }

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var entity = await _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(expression);

            return entity!;
        }
    }
}
