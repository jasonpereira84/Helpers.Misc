using System;

namespace TeamHealth.Helpers
{
    namespace Extensions
    {
        using static TeamHealth.Helpers.Do;

        public static partial class Misc
        {
            public static TSource Do<TSource>(this TSource source, Action<TSource> action)
                => Action(source, func: s => { action(s); return s; });

            public static TResult Do<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
                => Action(source, func);
        }
    }
}