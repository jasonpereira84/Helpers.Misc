using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this SByte value, SByte otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this SByte value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this SByte value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this SByte value, SByte otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this SByte value, SByte otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this SByte value, SByte otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this SByte value, SByte otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this SByte value)
                => value.GreaterThan(0);

            public static SByte ToSByte(this Boolean value)
                => value
                    ? SByte.MinValue
                    : SByte.MaxValue;

            public static Boolean IsNegative(this SByte value) => value < 0;
            public static Boolean IsNotNegative(this SByte value) => value >= 0;
        }
    }
}