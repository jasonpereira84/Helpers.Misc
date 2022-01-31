using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Decimal value, Decimal otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Decimal value, Decimal otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Decimal value, Decimal otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Decimal value, Decimal otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Decimal value, Decimal otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Decimal value)
                => value.Equals((Decimal)0);
            public static Boolean NotEqualsZero(this Decimal value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this Decimal value)
                => value.LessThan((Decimal)0);
            public static Boolean IsNotNegative(this Decimal value)
                => !value.IsNegative();
        }
    }
}