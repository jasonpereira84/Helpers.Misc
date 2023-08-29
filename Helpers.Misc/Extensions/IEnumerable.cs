using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean None<TSource>(this IEnumerable<TSource> source)
                => !source.Any();

            public static IEnumerable<TResult> SelectWhen<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector)
                => source.Where(predicate).Select(selector);

            public static IEnumerable<TResult> SelectWhen<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector, out IEnumerable<TResult> result)
                => result = SelectWhen(source, predicate, selector);

            public static Type GetItemType<TSource>(this IEnumerable<TSource> source)
                => typeof(TSource);

            public static TSource GetInstanceOfItemType<TSource>(this IEnumerable<TSource> source)
                => Activator.CreateInstance<TSource>();

            public static Boolean NotContains<TSource>(this IEnumerable<TSource> source, TSource value)
                => !source.Contains(value);

            public static Boolean ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values)
            {
                if (source.None())
                    return false;

                foreach (var value in values)
                    if (source.Contains(value))
                        return true;

                return false;
            }

            public static Boolean ContainsAll<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> values)
            {
                if (source.None())
                    return false;

                foreach (var value in values)
                    if (source.NotContains(value))
                        return false;

                return true;
            }

            public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
                where TSource : class
                => Enumerable.FirstOrDefault(source) ?? defaultValue;
            public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, TSource defaultValue)
                where TSource : class
                => Enumerable.FirstOrDefault(source, predicate) ?? defaultValue;
            public static Nullable<TSource> FirstOrDefault<TSource>(this IEnumerable<Nullable<TSource>> source, Nullable<TSource> defaultValue)
                where TSource : struct
                => Enumerable.FirstOrDefault(source) ?? defaultValue;
            public static Nullable<TSource> FirstOrDefault<TSource>(this IEnumerable<Nullable<TSource>> source, Func<Nullable<TSource>, Boolean> predicate, Nullable<TSource> defaultValue)
                where TSource : struct
                => Enumerable.FirstOrDefault(source, predicate) ?? defaultValue;

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

            public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, params IEnumerable<TSource>[] seconds)
            {
                foreach (var second in seconds)
                    first = Enumerable.Concat(first, second);
                return first;
            }
            public static IEnumerable<TSource> Concat<TSource>(params IEnumerable<TSource>[] sources)
                => Concat(Enumerable.Empty<TSource>(), sources);

            public static String AsString<TSource>(this IEnumerable<TSource> source, String separator, Func<TSource, String> stringifier)
                => String.Join(separator, source.Select(item => stringifier.Invoke(item)));
            public static String AsString<TSource>(this IEnumerable<TSource> source, Func<TSource, String> stringifier)
                => source.AsString(default(String), stringifier);
            public static String AsString<TSource>(this IEnumerable<TSource> source, String separator)
                => source.AsString(separator, x => $"{x}");
            public static String AsString<TSource>(this IEnumerable<TSource> source)
                => source.AsString(x => $"{x}");

            public static String AsString<TSource>(this IEnumerable<TSource> source, Char separator, Func<TSource, String> stringifier)
                => String.Join(separator, source.Select(item => stringifier.Invoke(item)));
            public static String AsString<TSource>(this IEnumerable<TSource> source, Char separator)
                => source.AsString(separator, x => $"{x}");

            #region IEnumerable<String>

#nullable enable
            public static String AsString(this IEnumerable<String?> source, String separator)
                => String.Join(separator, source);
            public static String AsString(this IEnumerable<String?> source)
                => String.Join(default(String), source);

            public static String AsString(this IEnumerable<String?> source, Char separator)
                => String.Join(separator, source);
#nullable disable

            #endregion IEnumerable<String>

            #region IEnumerable<KeyValuePair<TKey, String>>

            public static IEnumerable<KeyValuePair<TKey, String>> Sanitize<TKey>(this IEnumerable<KeyValuePair<TKey, String>> source, Func<String, Boolean> predicate)
                => source.Where(pair => predicate.Invoke(pair.Value));
            public static IEnumerable<KeyValuePair<TKey, String>> Sanitize<TKey>(this IEnumerable<KeyValuePair<TKey, String>> source)
                => source.Sanitize(value => value.IsNotNullOrEmptyOrWhiteSpace());

            #endregion IEnumerable<KeyValuePair<TKey, String>>

            #region IEnumerable<KeyValuePair<String, TValue>>

            public static IEnumerable<KeyValuePair<String, TValue>> Sanitize<TValue>(this IEnumerable<KeyValuePair<String, TValue>> source, Func<String, Boolean> predicate)
                => source.Where(pair => predicate.Invoke(pair.Key));
            public static IEnumerable<KeyValuePair<String, TValue>> Sanitize<TValue>(this IEnumerable<KeyValuePair<String, TValue>> source)
                => source.Sanitize(key => key.IsNotNullOrEmptyOrWhiteSpace());

            #endregion IEnumerable<KeyValuePair<String, TValue>>

            public static void ForEachWithIndex<TSource>(this IEnumerable<TSource> source, Action<Int32, TSource> action)
            {
                if (source == null) throw new ArgumentNullException(nameof(source));
                if (action == null) throw new ArgumentNullException(nameof(action));

                var index = 0;
                foreach (TSource item in source)
                {
                    action(index, item);
                    index++;
                }
            }
        }
    }
}