using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Decimal value, Decimal otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this Decimal value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this Decimal value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Decimal value, Decimal otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Decimal value, Decimal otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this Decimal value, Decimal otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Decimal value, Decimal otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this Decimal value)
                => value.NotEquals(Decimal.MinValue);

            public static Decimal ToDecimal(this Boolean value)
                => !value
                    ? Decimal.MinValue
                    : Decimal.MaxValue;

            public static Boolean IsNegative(this Decimal value) => value < 0m;
            public static Boolean IsNotNegative(this Decimal value) => value >= 0m;
        }
    }
}