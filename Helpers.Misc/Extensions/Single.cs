using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Single value, Single otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Single value, Single otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Single value, Single otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Single value, Single otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Single value, Single otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Single value)
                => value.Equals((Single)0);
            public static Boolean NotEqualsZero(this Single value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this Single value)
                => value.LessThan((Single)0);
            public static Boolean IsNotNegative(this Single value)
                => !value.IsNegative();
        }
    }
}