using System;
using System.Linq;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean Not(this Boolean value) => !value;

            public static Boolean IsNot(this Boolean value) => !value;

            public static Boolean IsTrue(this Boolean value) => value;

            public static Boolean IsFalse(this Boolean value) => !value;
        }
    }
}