using System;
using System.Linq;
using System.Collections.Generic;

namespace TeamHealth.Helpers
{
    namespace Extensions
    {
        using Internal;

        public static partial class Misc
        {
            public static Boolean None<TSource>(this IEnumerable<TSource> source)
                => !source.Any();

            public static Boolean None<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
                => !source.Any(predicate);

            public static Boolean IsNullOrNone<TSource>(this IEnumerable<TSource> source)
                => (source == null) || !source.Any();

            public static Boolean IsNullOrNone<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
                => (source == null) || !source.Any(predicate);

            public static Boolean IsNotNullOrNone<TSource>(this IEnumerable<TSource> source)
                => !IsNullOrNone(source);

            public static Boolean IsNotNullOrNone<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
                => !IsNullOrNone(source, predicate);

            public static IEnumerable<TResult> SelectWhen<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector)
                => source?.Where(predicate)?.Select(selector);

            public static IEnumerable<TResult> SelectWhen<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector, out IEnumerable<TResult> sink)
                => sink = SelectWhen(source, predicate, selector);

            public static Type GetItemType<TSource>(this IEnumerable<TSource> source)
                => typeof(TSource);

            public static TSource GetInstanceOfItemType<TSource>(this IEnumerable<TSource> source)
                => Activator.CreateInstance<TSource>();

            public static Boolean NotContains<TSource>(this IEnumerable<TSource> source, TSource value)
                => !source.Contains(value);

            public static Boolean IsOneOf<TSource>(this TSource value, params TSource[] source)
                => source.Contains(value);

            public static Boolean IsNotOneOf<TSource>(this TSource value, params TSource[] source)
                => !source.Contains(value);

            public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, TSource defaultValue)
                where TSource : class
                => source.FirstOrDefault(predicate) ?? defaultValue;

            public static Nullable<TSource> FirstOrDefault<TSource>(this IEnumerable<Nullable<TSource>> source, Func<Nullable<TSource>, Boolean> predicate, Nullable<TSource> defaultValue)
                where TSource : struct
                => source.FirstOrDefault(predicate) ?? defaultValue;
            
            public static IEnumerable<TSource> Each<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
            {
                foreach (var item in source)
                    action.Invoke(item);
                return source;
            }

            public static IEnumerable<TSource> Each<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Action<TSource> action)
            {
                foreach (var item in source)
                    if (predicate(item))
                        action.Invoke(item);
                return source;
            }

            public static IEnumerable<TSource> Sanitize<TSource>(this IEnumerable<TSource> source)
                => IsNotNullOrNone(source) ? source : Enumerable.Empty<TSource>();

            public static IEnumerable<TSource> Sanitize<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource> sanitizer)
                => Sanitize(source).Select(value => sanitizer.Invoke(value));

            public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, params IEnumerable<TSource>[] sources)
            {
                foreach (var src in sources)
                    source = Enumerable.Concat(source, src);
                return source;
            }
            public static IEnumerable<TSource> Concat<TSource>(params IEnumerable<TSource>[] sources)
                => Concat(Enumerable.Empty<TSource>(), sources);

            public static String AsString<TSource>(this IEnumerable<TSource> source, String separator, Func<TSource, String> stringifier)
                => String.Join(separator, source.Select(item => stringifier.Invoke(item)));

            public static IEnumerable<KeyValuePair<TKey, TElement>> AsKeyValuePairs<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> valueSelector)
                => source.Select(item => new KeyValuePair<TKey, TElement>(keySelector.Invoke(item), valueSelector.Invoke(item)));

            #region IEnumerable<String>

            public static String AsString(this IEnumerable<String> source, String separator)
                => String.Join(separator, source);

            #endregion IEnumerable<String>

            #region IEnumerable<KeyValuePair<Int32, String>>

            public static IEnumerable<KeyValuePair<Int32, String>> Sanitize(this IEnumerable<KeyValuePair<Int32, String>> source, Func<KeyValuePair<Int32, String>, Boolean> predicate)
                => source.Where(set => predicate.Invoke(set));

            public static IEnumerable<KeyValuePair<Int32, String>> Sanitize(this IEnumerable<KeyValuePair<Int32, String>> source, Func<String, Boolean> predicate)
                => Sanitize(source, set => predicate.Invoke(set.Value));

            public static IEnumerable<KeyValuePair<Int32, String>> Sanitize(this IEnumerable<KeyValuePair<Int32, String>> source)
                => Sanitize(source, value => !Helpers.IsNullOrEmptyOrWhiteSpace(value));

            #endregion IEnumerable<KeyValuePair<Int32, String>>
        }
    }
}