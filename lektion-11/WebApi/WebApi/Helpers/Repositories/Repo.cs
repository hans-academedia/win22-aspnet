using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;

namespace WebApi.Helpers.Repositories
{
    public abstract class Repo<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected Repo(DataContext context)
        {
            _context = context;
        }


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entities = await _context.Set<TEntity>().Where(expression).ToListAsync();
            return entities!;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
