using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    public static partial class If
    {
        private static TResult _if<TResult>(Boolean p, TResult t, TResult f) => p ? t : f;


        public static TResult Predicate<TResult>(Boolean predicate, TResult valueIfTrue, TResult valueIfFalse)
            => _if(predicate, valueIfTrue, valueIfFalse);

        public static TResult Predicate<TResult>(Boolean predicate, Func<TResult> funcIfTrue, Func<TResult> funcIfFalse)
            => _if(predicate, funcIfTrue, funcIfFalse).Invoke();

        public static void Predicate<TSource>(Boolean predicate, TSource source, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse)
            => _if(predicate, actionIfTrue, actionIfFalse).Invoke(source);
        public static void Predicate<TSource>(Func<Boolean> predicate, TSource source, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse)
            => Predicate(predicate(), source, actionIfTrue, actionIfFalse);
        public static void Predicate<TSource>(Func<TSource, Boolean> predicate, TSource source, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse)
            => Predicate(predicate(source), source, actionIfTrue, actionIfFalse);

        public static TResult Predicate<TSource, TResult>(Boolean predicate, TSource source, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
            => _if(predicate, funcIfTrue, funcIfFalse).Invoke(source);
        public static TResult Predicate<TSource, TResult>(Func<Boolean> predicate, TSource source, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
            => Predicate(predicate(), source, funcIfTrue, funcIfFalse);
        public static TResult Predicate<TSource, TResult>(Func<TSource, Boolean> predicate, TSource source, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
            => Predicate(predicate(source), source, funcIfTrue, funcIfFalse);
    }
}