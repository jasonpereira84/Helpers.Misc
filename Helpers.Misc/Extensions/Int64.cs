using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Int64 value, Int64 otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Int64 value, Int64 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Int64 value, Int64 otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Int64 value, Int64 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Int64 value, Int64 otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Int64 value)
                => value.Equals((Int64)0);
            public static Boolean NotEqualsZero(this Int64 value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this Int64 value)
                => value.LessThan((Int64)0);
            public static Boolean IsNotNegative(this Int64 value)
                => !value.IsNegative();
        }
    }
}