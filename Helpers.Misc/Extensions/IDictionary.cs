using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair)
                => dictionary.Add(pair.Key, pair.Value);

            public static Boolean NotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
                => !dictionary.ContainsKey(key);

            public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
                => dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;

        }
    }
}