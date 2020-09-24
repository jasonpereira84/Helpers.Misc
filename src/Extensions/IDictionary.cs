using System;
using System.Linq;
using System.Collections.Generic;

namespace TeamHealth.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
            => dictionary.Add(pair.Key, pair.Value);

            public static Boolean NotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
                => !dictionary.ContainsKey(key);

            public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
                => dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;


            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, TKey key, TValue value)
                where TDictionary : IDictionary<TKey, TValue>
            {
                if (dictionary.NotContainsKey(key))
                    dictionary.Add(key, value);

                return dictionary;
            }

            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, params KeyValuePair<TKey, TValue>[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair);

                return dictionary;
            }

            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair);

                return dictionary;
            }

            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, params (TKey Key, TValue Value)[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair.Key, pair.Value);

                return dictionary;
            }

            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<(TKey Key, TValue Value)> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair.Key, pair.Value);

                return dictionary;
            }



            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, TKey key, TValue value)
                where TDictionary : IDictionary<TKey, TValue>
            {
                if (dictionary.ContainsKey(key))
                    dictionary[key] = value;
                else
                    dictionary.Add(key, value);

                return dictionary;
            }

            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, params KeyValuePair<TKey, TValue>[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                {
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair);
                    else
                        dictionary[pair.Key] = pair.Value;
                }

                return dictionary;
            }

            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                {
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair);
                    else
                        dictionary[pair.Key] = pair.Value;
                }

                return dictionary;
            }

            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, params (TKey Key, TValue Value)[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                {
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair.Key, pair.Value);
                    else
                        dictionary[pair.Key] = pair.Value;
                }

                return dictionary;
            }

            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<(TKey Key, TValue Value)> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                {
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair.Key, pair.Value);
                    else
                        dictionary[pair.Key] = pair.Value;
                }

                return dictionary;
            }


            public static TDictionary Each<TKey, TValue, TDictionary>(this TDictionary dictionary, Action<KeyValuePair<TKey, TValue>> action)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var item in dictionary)
                    action.Invoke(item);
                return dictionary;
            }

            public static TDictionary Each<TKey, TValue, TDictionary>(this TDictionary dictionary, Func<KeyValuePair<TKey, TValue>, Boolean> predicate, Action<KeyValuePair<TKey, TValue>> action)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var item in dictionary)
                    if (predicate(item))
                        action.Invoke(item);
                return dictionary;
            }

            public static Boolean TryGetValueOrDefault<TKey, TValue, TDictionary>(this TDictionary dictionary, TKey key, TValue defaultValue, out TValue value)
                where TDictionary : IDictionary<TKey, TValue>
            {
                if (dictionary.TryGetValue(key, out value))
                    return true;

                value = defaultValue;
                return false;
            }

            public static Dictionary<TKey, TValueResult> AsDictionary<TValueSource, TKey, TValueResult>(this IDictionary<TKey, TValueSource> dictionary, Func<TKey, TValueSource, TValueResult> selector)
                => dictionary.ToDictionary(item => item.Key, item => selector.Invoke(item.Key, item.Value));

            public static Dictionary<TKey, TValueResult> AsDictionary<TValueSource, TKey, TValueResult>(this IDictionary<TKey, TValueSource> dictionary, Func<TKey, TValueSource, TValueResult> selector, out Dictionary<TKey, TValueResult> sink)
                => sink = AsDictionary(dictionary, selector);
            #region IDictionary<String, X>

            public static Boolean ReallyTryGetValueOrDefault<TValue, TDictionary>(this TDictionary dictionary, String key, TValue defaultValue, out TValue value)
                where TDictionary : IDictionary<String, TValue>
            {
                if (TryGetValueOrDefault(dictionary, key, defaultValue, out value))
                    return true;

                var actualKey = dictionary.Keys.FirstOrDefault(k => k.Matches(key));
                if (actualKey.IsNotNull())
                    if (TryGetValueOrDefault(dictionary, actualKey, defaultValue, out value))
                        return true;

                return false;
            }
            #endregion
        }
    }
}