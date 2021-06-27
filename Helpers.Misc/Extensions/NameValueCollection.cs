using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static IEnumerable<KeyValuePair<String, String>> ToPairs(this NameValueCollection nameValueCollection)
            {
                var collection = nameValueCollection ?? throw new ArgumentNullException(nameof(nameValueCollection));
                return collection.Cast<String>().Select(key => new KeyValuePair<String, String>(key, collection[key]));
            }
        }
    }
}
