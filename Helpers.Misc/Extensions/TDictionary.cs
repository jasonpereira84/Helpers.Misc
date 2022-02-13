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

            #region TDictionary<String, TValue>

            public static Boolean ReallyTryGetValue<TValue, TDictionary>(this TDictionary dictionary, String key, out TValue value)
                where TDictionary : IDictionary<String, TValue>
            {
                if (dictionary.TryGetValue(key, out value))
                    return true;

                var actualKey = dictionary.Keys.FirstOrDefault(k => k.Matches(key));
                if (actualKey.IsNotNull())
                    if (dictionary.TryGetValue(actualKey, out value))
                        return true;

                value = default(TValue);
                return false;
            }

            #endregion TDictionary<String, TValue>
        }
    }
}