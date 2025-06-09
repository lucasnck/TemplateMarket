using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TemplateMarket.Application.Common.Models;

namespace TemplateMarket.Application.Common.Extensions;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<TResult>> ToPaginatedResultAsync<TEntity, TResult>(
        this IQueryable<TEntity> query,
        ISieveProcessor sieve,
        IMapper mapper,
        SieveModel sieveModel,
        CancellationToken ct = default)
        where TEntity : class
    {
        var filtered = sieve.Apply(sieveModel, query);

        var total = await filtered.CountAsync(ct);
        var page = sieveModel.Page ?? 1;
        var pageSize = sieveModel.PageSize ?? 10;

        var items = await filtered
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .ToListAsync(ct);

        return new PaginatedResult<TResult>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        };
    }
}
