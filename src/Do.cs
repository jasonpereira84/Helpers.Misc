using System;

namespace TeamHealth.Helpers
{
    public static partial class Do
    {
        public static void Nothing(Object obj) { return; }

        public static void Nothing<TSource>(TSource source) { return; }

        public static TSource NothingWith<TSource>(TSource source) { return source; }

        public static TResult Action<TSource, TResult>(TSource source, Func<TSource, TResult> func)
            => func.Invoke(source);
    }
}