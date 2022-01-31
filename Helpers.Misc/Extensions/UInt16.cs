using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this UInt16 value, UInt16 otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this UInt16 value, UInt16 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this UInt16 value, UInt16 otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this UInt16 value, UInt16 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this UInt16 value, UInt16 otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this UInt16 value)
                => value.Equals((UInt16)0);
            public static Boolean NotEqualsZero(this UInt16 value)
                => !value.EqualsZero();

        }
    }
}