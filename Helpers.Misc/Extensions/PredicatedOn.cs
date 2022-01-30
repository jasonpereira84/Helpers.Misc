using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            private static TResult _if<TResult>(Boolean p, TResult t, TResult f) 
                => p ? t : f;

            public static TResult PredicatedOn<TResult>(Boolean predicate, TResult valueIfTrue, TResult valueIfFalse)
                => _if(predicate, valueIfTrue, valueIfFalse);

            public static TResult PredicatedOn<TResult>(Boolean predicate, Func<TResult> funcIfTrue, Func<TResult> funcIfFalse)
                => _if(predicate, funcIfTrue, funcIfFalse).Invoke();

            public static void PredicatedOn<TSource>(Boolean predicate, TSource source, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse)
                => _if(predicate, actionIfTrue, actionIfFalse).Invoke(source);
            public static void PredicatedOn<TSource>(Func<Boolean> predicate, TSource source, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse)
                => PredicatedOn(predicate.Invoke(), source, actionIfTrue, actionIfFalse);
            public static void PredicatedOn<TSource>(Func<TSource, Boolean> predicate, TSource source, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse)
                => PredicatedOn(predicate.Invoke(source), source, actionIfTrue, actionIfFalse);

            public static TResult PredicatedOn<TSource, TResult>(Boolean predicate, TSource source, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => _if(predicate, funcIfTrue, funcIfFalse).Invoke(source);
            public static TResult PredicatedOn<TSource, TResult>(Func<Boolean> predicate, TSource source, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => PredicatedOn(predicate.Invoke(), source, funcIfTrue, funcIfFalse);
            public static TResult PredicatedOn<TSource, TResult>(Func<TSource, Boolean> predicate, TSource source, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => PredicatedOn(predicate.Invoke(source), source, funcIfTrue, funcIfFalse);
        }
    }
}