using System.Linq.Expressions;
using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;

namespace TemplateMarket.Application.Common.Extensions;

public static class RepositoryExtensions
{
    public static async Task<T> SingleOrThrow<T>(
        this IRepository repository,
        Expression<Func<T, bool>> predicate
    ) where T : class
        {
            var entity = await repository.SingleOrDefaultAsync(predicate);
            return entity ?? throw new NotFoundException(typeof(T).Name);
        }
}
