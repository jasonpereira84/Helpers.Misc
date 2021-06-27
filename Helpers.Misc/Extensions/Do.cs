using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        using static JasonPereira84.Helpers.Do;

        public static partial class Misc
        {
            public static TSource Do<TSource>(this TSource source, Action<TSource> action)
                => Action(source, func: s => { action(s); return s; });

            public static TResult Do<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
                => Action(source, func);
        }
    }
}