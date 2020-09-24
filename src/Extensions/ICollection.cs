using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static ICollection<TSource> Sanitize<TSource>(this ICollection<TSource> source, Func<TSource, Boolean> predicate, ICollection<TSource> defaultValue = default(ICollection<TSource>))
            => (source?.Where(predicate) ?? defaultValue)?.ToList();

            public static ICollection<TResult> Sanitize<TSource, TResult>(this ICollection<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector, ICollection<TSource> defaultValue = default(ICollection<TSource>))
                => (Sanitize(source, predicate, defaultValue) ?? defaultValue)?.Select(selector)?.ToList();

        }
    }
}