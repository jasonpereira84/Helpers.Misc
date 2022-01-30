using System;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static T AddItem<T>(this IList<T> source, Func<T> func)
            {
                var item = func.Invoke();
                source.Add(item);
                return item;
            }

        }
    }
}