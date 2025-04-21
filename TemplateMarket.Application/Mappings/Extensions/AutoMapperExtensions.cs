using System.Linq.Expressions;
using AutoMapper;

namespace TemplateMarket.Application.Mappings.Extensions;

public static class AutoMapperExtensions
{
    public static IMappingExpression<TSource, TDestination> ForNullableDecimal<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> map,
        Expression<Func<TDestination, decimal>> destinationMember,
        Expression<Func<TSource, decimal?>>? sourceMember = null
    )
    {
        if (sourceMember is null)
        {
            // Assume mesmo nome da propriedade se não passar sourceMember
            var sourceParam = Expression.Parameter(typeof(TSource), "src");
            var destMemberName = ((MemberExpression)destinationMember.Body).Member.Name;
            var sourceMemberAccess = Expression.PropertyOrField(sourceParam, destMemberName);
            sourceMember = Expression.Lambda<Func<TSource, decimal?>>(sourceMemberAccess, sourceParam);
        }

        map.ForMember(destinationMember,
            opt =>
            {
                opt.PreCondition(src => sourceMember.Compile().Invoke(src).HasValue);
                opt.MapFrom(src => sourceMember.Compile().Invoke(src)!.Value);
            });

        return map;
    }
    public static IMappingExpression<TSource, TDestination> ForNullableBool<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> map,
        Expression<Func<TDestination, bool>> destinationMember,
        Expression<Func<TSource, bool?>>? sourceMember = null
    )
    {
        if (sourceMember is null)
        {
            // Assume mesmo nome da propriedade se não passar sourceMember
            var sourceParam = Expression.Parameter(typeof(TSource), "src");
            var destMemberName = ((MemberExpression)destinationMember.Body).Member.Name;
            var sourceMemberAccess = Expression.PropertyOrField(sourceParam, destMemberName);
            sourceMember = Expression.Lambda<Func<TSource, bool?>>(sourceMemberAccess, sourceParam);
        }

        map.ForMember(destinationMember,
            opt =>
            {
                opt.PreCondition(src => sourceMember.Compile().Invoke(src).HasValue);
                opt.MapFrom(src => sourceMember.Compile().Invoke(src)!.Value);
            });

        return map;
    }
}
