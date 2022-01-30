using System;
using System.Linq;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean IsOneOf<TSource>(this TSource value, params TSource[] source)
                => source.Contains(value);

            public static Boolean IsNotOneOf<TSource>(this TSource value, params TSource[] source)
                => !value.IsOneOf(source);

#nullable enable
            public static String AsString<TSource>(String? separator, Func<TSource, String> stringifier, params TSource[] items)
                => items.AsString(separator, stringifier);
            public static String AsString<TSource>(String? separator, params TSource[] items)
                => items.AsString(separator);
#nullable disable

        }
    }
}