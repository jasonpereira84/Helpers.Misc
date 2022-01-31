using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static TResult If<TResult>(this Boolean predicate, TResult valueIfTrue, TResult valueIfFalse)
                => PredicatedOn(predicate, valueIfTrue, valueIfFalse);

            public static TResult If<TResult>(this Boolean predicate, Func<TResult> funcIfTrue, Func<TResult> funcIfFalse)
                => PredicatedOn(predicate, funcIfTrue, funcIfFalse);

            public static void If<TSource>(this TSource source, Boolean predicate, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse = null)
                => PredicatedOn(predicate, source, actionIfTrue, actionIfFalse ?? Helpers.Do.Nothing);
            public static void If<TSource>(this TSource source, Func<Boolean> predicate, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse = null)
                => PredicatedOn(predicate, source, actionIfTrue, actionIfFalse ?? Helpers.Do.Nothing);
            public static void If<TSource>(this TSource source, Func<TSource, Boolean> predicate, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse = null)
                => PredicatedOn(predicate, source, actionIfTrue, actionIfFalse ?? Helpers.Do.Nothing);


            public static TResult If<TSource, TResult>(this TSource source, Boolean predicate, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => PredicatedOn(predicate, source, funcIfTrue, funcIfFalse);
            public static TResult If<TSource, TResult>(this TSource source, Func<Boolean> predicate, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => PredicatedOn(predicate, source, funcIfTrue, funcIfFalse);
            public static TResult If<TSource, TResult>(this TSource source, Func<TSource, Boolean> predicate, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => PredicatedOn(predicate, source, funcIfTrue, funcIfFalse);


            public static TSource If<TSource>(this TSource source, Boolean predicate, Func<TSource, TSource> funcIfTrue)
                => PredicatedOn(predicate,source, funcIfTrue, Helpers.Do.NothingWith);
            public static TSource If<TSource>(this TSource source, Func<Boolean> predicate, Func<TSource, TSource> funcIfTrue)
                => PredicatedOn(predicate, source, funcIfTrue, Helpers.Do.NothingWith);
            public static TSource If<TSource>(this TSource source, Func<TSource, Boolean> predicate, Func<TSource, TSource> funcIfTrue)
                => PredicatedOn(predicate, source, funcIfTrue, Helpers.Do.NothingWith);
        }
    }
}