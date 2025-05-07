// Infrastructure/Persistence/Repositories/Repository.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using TemplateMarket.Application.Common.Interfaces;

namespace TemplateMarket.Infrastructure.Persistence.Repositories;

public class Repository(ApplicationDbContext context) : IRepository
{
    public IQueryable<T> Query<T>() where T : class => context.Set<T>();

    public IQueryable<T> QueryWithoutFilter<T>() where T : class =>
        context.Set<T>().IgnoreQueryFilters();

    public async Task<T?> GetByIdAsync<T>(long id) where T : class =>
        await context.Set<T>().FindAsync(id);

    public async Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class =>
        await context.Set<T>().SingleOrDefaultAsync(predicate);

    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class =>
        await context.Set<T>().Where(predicate).ToListAsync();

    public async Task AddAsync<T>(T entity) where T : class =>
        await context.Set<T>().AddAsync(entity);

    public void Remove<T>(T entity) where T : class =>
        context.Set<T>().Remove(entity);

    public Task UpdateAsync<T>(T entity) where T : class
    {
        context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync() => context.SaveChangesAsync();
}
