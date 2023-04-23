using _01_AspNet_MVC.Helpers.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _01_AspNet_MVC.Helpers.Repositories
{
    public abstract class Repo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public Repo(DataContext context)
        {
            _context = context;
        }


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var item = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return item!;
        }
    }
}
