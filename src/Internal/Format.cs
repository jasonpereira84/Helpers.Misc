﻿using System;

namespace TeamHealth.Helpers
{
    namespace Internal
    {
        internal static partial class Helpers
        {
            public static String GetFormat(String format, String separator, params String[] source)
                => String.Format(format, String.Join(separator, source));
            public static String GetFormat(String format, params String[] source)
                => GetFormat(format, ", ", source);

            public static String GetFormatForSet(String name)
                => String.Format("\"{0}\": {{0}}", name);

            public static String GetFormatForPair(String name)
                => String.Format("\"{0}\": \"{{0}}\"", name);
        }
    }
}
