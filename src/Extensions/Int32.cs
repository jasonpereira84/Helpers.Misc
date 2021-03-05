using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Int32 value, Int32 otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this Int32 value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this Int32 value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Int32 value, Int32 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Int32 value, Int32 otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this Int32 value, Int32 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Int32 value, Int32 otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this Int32 value)
                => value.GreaterThan(0);

            public static Int32 ToInt32(this Boolean value)
                => value
                    ? Int32.MinValue
                    : Int32.MaxValue;

            public static Boolean IsNegative(this Int32 value) => value < 0;
            public static Boolean IsNotNegative(this Int32 value) => value >= 0;

            #region Nullable
            public static Boolean HasValue(this Nullable<Int32> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<Int32> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<Int32> value, Int32 otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<Int32> value, Int32 otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}