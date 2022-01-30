using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Int16 value, Int16 otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Int16 value, Int16 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Int16 value, Int16 otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Int16 value, Int16 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Int16 value, Int16 otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Int16 value)
                => value.Equals((Int16)0);
            public static Boolean NotEqualsZero(this Int16 value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this Int16 value)
                => value.LessThan((Int16)0);
            public static Boolean IsNotNegative(this Int16 value)
                => !value.IsNegative();
        }
    }
}