using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static String Fullname(this IPerson person, String format)
                => format
                    .Replace($"{{{nameof(IPerson.Last)}}}", person.Last)
                    .Replace($"{{{nameof(IPerson.First)}}}", person.First);
        }
    }
}