using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static TList AddItem<T, TList>(this TList source, T item)
                where TList : IList<T>
            {
                source.Add(item);
                return source;
            }

            public static TList EnsureAtLeastOne<T, TList>(this TList source, T item)
                where TList : IList<T>
                => source.Any() ? source : source.AddItem(item);
            public static TList EnsureAtLeastOne<T, TList>(this TList source)
                where TList : IList<T>
                => source.EnsureAtLeastOne(Activator.CreateInstance<T>());
        }
    }
}