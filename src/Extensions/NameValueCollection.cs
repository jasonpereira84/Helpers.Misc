using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace TeamHealth.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static IEnumerable<KeyValuePair<String, String>> ToPairs(this NameValueCollection collection)
            {
                Ensure.Argument.IsNotNull(collection, nameof(collection));
                return collection.Cast<String>().Select(key => new KeyValuePair<String, String>(key, collection[key]));
            }
        }
    }
}
