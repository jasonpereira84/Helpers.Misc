using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        using Internal;

        public static partial class Misc
        {
            public static Boolean IsNull<T>(this T t) where T : class => t == null;

            public static Boolean IsNotNull<T>(this T t) where T : class => t != null;
        }
    }
}