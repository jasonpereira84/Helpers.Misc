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
            public static IEnumerable<KeyValuePair<String, String>> AsPairs(this NameValueCollection nameValueCollection)
                => nameValueCollection == null
                    ? throw new ArgumentNullException(nameof(nameValueCollection))
                    : nameValueCollection.Cast<String>().Select(key => new KeyValuePair<String, String>(key, nameValueCollection[key]));

        }
    }
}
