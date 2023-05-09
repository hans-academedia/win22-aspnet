using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

namespace WebApi.Repos;

public class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public Repo(DataContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

}
