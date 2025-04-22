using System.Linq.Expressions;
using AutoMapper;
using TemplateMarket.Domain.Common.Entities;

namespace TemplateMarket.Application.Mappings.Extensions;

public static class AutoMapperExtensions
{
    public static IMappingExpression<TSource, TDestination> ApplyBaseUpdateRules<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> map)
        where TDestination : BaseEntity
    {
        map.ForMember(dest => dest.Id, o => o.Ignore());
        map.ForMember(dest => dest.CreatedDate, o => o.Ignore());
        map.ForMember(dest => dest.UpdatedDate, o => o.Ignore());

        map.ForAllMembers(opt =>
            opt.Condition((src, dest, srcMember) => srcMember != null));

        return map;
    }

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
            // mesmo nome de propriedade, mas converte para bool?
            var sourceParam = Expression.Parameter(typeof(TSource), "src");
            var destName = ((MemberExpression)destinationMember.Body).Member.Name;
            var rawAccess = Expression.PropertyOrField(sourceParam, destName);

            // Se rawAccess.Type == typeof(bool),
            // converte para Nullable<bool>
            var converted = Expression.Convert(rawAccess, typeof(bool?));

            sourceMember = Expression.Lambda<Func<TSource, bool?>>(converted, sourceParam);
        }

        var sourceFunc = sourceMember.Compile();

        map.ForMember(destinationMember, opt =>
        {
            opt.PreCondition(src => sourceFunc(src).HasValue);
            opt.MapFrom(src => sourceFunc(src)!.Value);
        });

        return map;
    }
}
