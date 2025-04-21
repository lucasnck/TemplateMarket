// Infrastructure/Persistence/Repositories/Repository.cs
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TemplateMarket.Application.Common.Interfaces;
using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(long id) =>
    await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<T?> GetByIdWithoutFilterAsync(long id) =>
        await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
        await _dbSet.Where(predicate).ToListAsync();

    public void Remove(T entity) => _dbSet.Remove(entity);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }
}
