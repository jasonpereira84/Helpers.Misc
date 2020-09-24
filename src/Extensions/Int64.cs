using System;

namespace TeamHealth.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Int64 value, Int64 otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this Int64 value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this Int64 value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Int64 value, Int64 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Int64 value, Int64 otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this Int64 value, Int64 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Int64 value, Int64 otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this Int64 value)
                => value.GreaterThan(0);

            public static Int64 ToInt64(this Boolean value)
                => value
                    ? Int64.MinValue
                    : Int64.MaxValue;

            #region Nullable
            public static Boolean HasValue(this Nullable<Int64> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<Int64> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<Int64> value, Int64 otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<Int64> value, Int64 otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}