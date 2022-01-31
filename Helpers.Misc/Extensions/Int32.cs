using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Int32 value, Int32 otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Int32 value, Int32 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Int32 value, Int32 otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Int32 value, Int32 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Int32 value, Int32 otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Int32 value)
                => value.Equals((Int32)0);
            public static Boolean NotEqualsZero(this Int32 value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this Int32 value)
                => value.LessThan((Int32)0);
            public static Boolean IsNotNegative(this Int32 value)
                => !value.IsNegative();
        }
    }
}