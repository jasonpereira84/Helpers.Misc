using System;
using System.Linq;
using System.Linq.Expressions;

namespace TeamHealth.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean None<TSource>(this IQueryable<TSource> source)
            => !source.Any();

            public static Boolean None<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
                => !source.Any(predicate);

            public static Boolean NullOrNone<TSource>(this IQueryable<TSource> source)
                => source?.None() ?? true;

            public static Boolean NullOrNone<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
                => source?.None(predicate) ?? true;

        }
    }
}