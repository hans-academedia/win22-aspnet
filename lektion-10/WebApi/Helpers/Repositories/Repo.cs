using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
            try
            {
                var item = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                return item!;
            }
            catch { return null!; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<TEntity>().ToListAsync();
                return items!;
            }
            catch { return null!; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var items = await _context.Set<TEntity>().Where(expression).ToListAsync();
                return items!;
            } 
            catch { return null!; }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            } 
            catch { return null!; }
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            } 
            catch {  return false; }
        }

    }
}



/*   
   
    TEntity = ProductEntity 
    Expression<Func<TEntity, bool>> expression       =>      x => x.ArticleNumber == articleNumber
    Expression<Func<TEntity, bool>> expression       =>      product => product.ArticleNumber == articleNumber

    TEntity = TagEntity 
    Expression<Func<TEntity, bool>> expression       =>      x => x.Id == tagId
    Expression<Func<TEntity, bool>> expression       =>      x => x.TagName == tagName

    TEntity = ProductEntity 
    _context.Set<TEntity>().Add(entity);   =>    _context.Products.Add(entity);

    TEntity = ProductCategoryEntity 
    _context.Set<TEntity>().Add(entity);   =>    _context.ProductCategories.Add(entity);

    TEntity = TagEntity 
    _context.Set<TEntity>().Add(entity);   =>    _context.Tags.Add(entity);
 
    TEntity = ProductTagEntity 
    _context.Set<TEntity>().Add(entity);   =>    _context.ProductTags.Add(entity);
*/