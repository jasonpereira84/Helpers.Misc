using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    internal static partial class _internalHelpers
    {
        public static Boolean None<TSource>(this IEnumerable<TSource> source)
            => !source.Any();

        public static Boolean None<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
            => !source.Any(predicate);

        public static Boolean IsNullOrNone<TSource>(this IEnumerable<TSource> source)
            => (source == null) || !source.Any();

        public static Boolean IsNullOrNone<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
            => (source == null) || !source.Any(predicate);
    }
}