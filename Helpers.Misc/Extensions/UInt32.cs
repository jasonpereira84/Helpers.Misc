using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this UInt32 value, UInt32 otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this UInt32 value, UInt32 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this UInt32 value, UInt32 otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this UInt32 value, UInt32 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this UInt32 value, UInt32 otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this UInt32 value)
                => value.Equals((UInt32)0);
            public static Boolean NotEqualsZero(this UInt32 value)
                => !value.EqualsZero();
        }
    }
}