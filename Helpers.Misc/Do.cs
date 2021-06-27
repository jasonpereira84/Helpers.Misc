using System;

namespace JasonPereira84.Helpers
{
    public static partial class Do
    {
        public static void Nothing<TSource>(TSource source) { return; }

        public static TSource NothingWith<TSource>(TSource source) { return source; }

        public static TResult Action<TSource, TResult>(TSource source, Func<TSource, TResult> func)
            => func.Invoke(source);
    }
}