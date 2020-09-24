using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Int16 value, Int16 otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this Int16 value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this Int16 value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Int16 value, Int16 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Int16 value, Int16 otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this Int16 value, Int16 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Int16 value, Int16 otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this Int16 value)
                => value.GreaterThan(0);

            public static Int16 ToInt16(this Boolean value)
                => value
                    ? Int16.MinValue
                    : Int16.MaxValue;

            #region Nullable
            public static Boolean HasValue(this Nullable<Int16> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<Int16> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<Int16> value, Int16 otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<Int16> value, Int16 otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}