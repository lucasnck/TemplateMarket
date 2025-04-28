// Application/Common/Interfaces/IRepository.cs
using System.Linq.Expressions;

namespace TemplateMarket.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(long id);
    Task<T?> GetByIdWithoutFilterAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Remove(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();
}
