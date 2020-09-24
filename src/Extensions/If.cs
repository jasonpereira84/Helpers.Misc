using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static TResult If<TResult>(this Boolean predicate, TResult valueIfTrue, TResult valueIfFalse)
                => Helpers.If.Predicate(predicate, valueIfTrue, valueIfFalse);

            public static TResult If<TResult>(this Boolean predicate, Func<TResult> funcIfTrue, Func<TResult> funcIfFalse)
                => Helpers.If.Predicate(predicate, funcIfTrue, funcIfFalse);

            public static void If<TSource>(this TSource source, Boolean predicate, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse = null)
                => Helpers.If.Predicate(predicate, source, actionIfTrue, actionIfFalse ?? Helpers.Do.Nothing);
            public static void If<TSource>(this TSource source, Func<Boolean> predicate, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse = null)
                => Helpers.If.Predicate(predicate, source, actionIfTrue, actionIfFalse ?? Helpers.Do.Nothing);
            public static void If<TSource>(this TSource source, Func<TSource, Boolean> predicate, Action<TSource> actionIfTrue, Action<TSource> actionIfFalse = null)
                => Helpers.If.Predicate(predicate, source, actionIfTrue, actionIfFalse ?? Helpers.Do.Nothing);


            public static TResult If<TSource, TResult>(this TSource source, Boolean predicate, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => Helpers.If.Predicate(predicate, source, funcIfTrue, funcIfFalse);
            public static TResult If<TSource, TResult>(this TSource source, Func<Boolean> predicate, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => Helpers.If.Predicate(predicate, source, funcIfTrue, funcIfFalse);
            public static TResult If<TSource, TResult>(this TSource source, Func<TSource, Boolean> predicate, Func<TSource, TResult> funcIfTrue, Func<TSource, TResult> funcIfFalse)
                => Helpers.If.Predicate(predicate, source, funcIfTrue, funcIfFalse);


            public static TSource If<TSource>(this TSource source, Boolean predicate, Func<TSource, TSource> funcIfTrue)
                => Helpers.If.Predicate(predicate,source, funcIfTrue, Helpers.Do.NothingWith);
            public static TSource If<TSource>(this TSource source, Func<Boolean> predicate, Func<TSource, TSource> funcIfTrue)
                => Helpers.If.Predicate(predicate, source, funcIfTrue, Helpers.Do.NothingWith);
            public static TSource If<TSource>(this TSource source, Func<TSource, Boolean> predicate, Func<TSource, TSource> funcIfTrue)
                => Helpers.If.Predicate(predicate, source, funcIfTrue, Helpers.Do.NothingWith);
        }
    }
}