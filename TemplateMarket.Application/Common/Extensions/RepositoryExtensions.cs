using TemplateMarket.Application.Common.Exceptions;
using TemplateMarket.Application.Common.Interfaces;

namespace TemplateMarket.Application.Common.Extensions;

public static class RepositoryExtensions
{
    public static async Task<T> GetOrThrow<T>(this IRepository<T> repository, long id)
        where T : class
    {
        var entity = await repository.GetByIdAsync(id);
        return entity ?? throw new NotFoundException(typeof(T).Name, id);
    }
}
