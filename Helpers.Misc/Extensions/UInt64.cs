using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this UInt64 value, UInt64 otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this UInt64 value, UInt64 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this UInt64 value, UInt64 otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this UInt64 value, UInt64 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this UInt64 value, UInt64 otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this UInt64 value)
                => value.Equals((UInt64)0);
            public static Boolean NotEqualsZero(this UInt64 value)
                => !value.EqualsZero();
        }
    }
}