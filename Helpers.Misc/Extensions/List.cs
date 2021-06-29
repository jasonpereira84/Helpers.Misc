using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static List<TSource> AddItem<TSource>(this List<TSource> source, TSource item)
            {
                source.Add(item);
                return source;
            }

            public static TSource AddItem<TSource>(this List<TSource> source, Func<TSource> func)
            {
                var item = func.Invoke();
                source.Add(item);
                return item;
            }

            public static List<TSource> EnsureAtLeastOne<TSource>(this List<TSource> source)
                => source.Any() ? source : source.AddItem(Activator.CreateInstance<TSource>());
        }
    }
}