using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static TDictionary Add<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    dictionary.Add(pair);
                return dictionary;
            }
            public static TDictionary Add<TKey, TValue, TDictionary>(this TDictionary dictionary, params KeyValuePair<TKey, TValue>[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
                => dictionary.Add(pairs.AsEnumerable());

            public static TDictionary Add<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<(TKey Key, TValue Value)> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    dictionary.Add(pair.Key, pair.Value);
                return dictionary;
            }
            public static TDictionary Add<TKey, TValue, TDictionary>(this TDictionary dictionary, params (TKey Key, TValue Value)[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
                => dictionary.Add(pairs.AsEnumerable());

            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair);
                return dictionary;
            }
            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, params KeyValuePair<TKey, TValue>[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
                => dictionary.AddIfNew(pairs.AsEnumerable());

            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, IEnumerable<(TKey Key, TValue Value)> pairs)
                where TDictionary : IDictionary<TKey, TValue>
            {
                foreach (var pair in pairs)
                    if (dictionary.NotContainsKey(pair.Key))
                        dictionary.Add(pair.Key, pair.Value);

                return dictionary;
            }
            public static TDictionary AddIfNew<TKey, TValue, TDictionary>(this TDictionary dictionary, params (TKey Key, TValue Value)[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
                => dictionary.AddIfNew(pairs.AsEnumerable());


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
            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, params KeyValuePair<TKey, TValue>[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
                => dictionary.AddIfNewOrUpdate(pairs.AsEnumerable());

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
            public static TDictionary AddIfNewOrUpdate<TKey, TValue, TDictionary>(this TDictionary dictionary, params (TKey Key, TValue Value)[] pairs)
                where TDictionary : IDictionary<TKey, TValue>
                => dictionary.AddIfNewOrUpdate(pairs.AsEnumerable());


            public static Boolean TryGetValueOrDefault<TKey, TValue, TDictionary>(this TDictionary dictionary, TKey key, out TValue value, TValue defaultValue = default(TValue))
                where TDictionary : IDictionary<TKey, TValue>
            {
                if (dictionary.TryGetValue(key, out value))
                    return true;

                value = defaultValue;
                return false;
            }


            #region TDictionary<String, TValue>

            public static Boolean ReallyTryGetValueOrDefault<TValue, TDictionary>(this TDictionary dictionary, String key, out TValue value, TValue defaultValue = default(TValue))
                where TDictionary : IDictionary<String, TValue>
            {
                if (TryGetValueOrDefault(dictionary, key, out value, defaultValue))
                    return true;

                var actualKey = dictionary.Keys.FirstOrDefault(k => k.Matches(key));
                if (actualKey.IsNotNull())
                    if (TryGetValueOrDefault(dictionary, actualKey, out value, defaultValue))
                        return true;

                return false;
            }

            #endregion TDictionary<String, TValue>
        }
    }
}