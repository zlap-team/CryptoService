using System.Linq.Expressions;
using Application.Contracts.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Common;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly CryptoDbContext _context;

    public BaseRepository(CryptoDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> criteria)
    {
        var result = await _context.Set<T>().FirstOrDefaultAsync(criteria);
        return result;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var results = await _context.Set<T>().ToListAsync();
        return results;
    }

    public async Task<bool> CheckIfExistsAsync(Expression<Func<T, bool>> criteria)
    {
        var result = await GetAsync(criteria);
        
        return result != null;
    }

    public async Task<T> AddAsync(T entity)
    {
        var result = await _context.AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}