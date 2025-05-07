// Application/Common/Interfaces/IRepository.cs
using System.Linq.Expressions;

namespace TemplateMarket.Application.Common.Interfaces;

public interface IRepository
{
    IQueryable<T> Query<T>() where T : class;
    IQueryable<T> QueryWithoutFilter<T>() where T : class;
    Task<T?> GetByIdAsync<T>(long id) where T : class;
    Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

    Task AddAsync<T>(T entity) where T : class;
    void Remove<T>(T entity) where T : class;
    Task UpdateAsync<T>(T entity) where T : class;
    Task SaveChangesAsync();
}