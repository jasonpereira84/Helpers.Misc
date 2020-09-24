using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this UInt64 value, UInt64 otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this UInt64 value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this UInt64 value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this UInt64 value, UInt64 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this UInt64 value, UInt64 otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this UInt64 value, UInt64 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this UInt64 value, UInt64 otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this UInt64 value)
                => value.NotEquals(UInt64.MinValue);

            public static UInt64 ToUInt64(this Boolean value)
                => value
                    ? UInt64.MinValue
                    : UInt64.MaxValue;

            public static UInt64 ToUInt64(this Int64 value, Int64 maxValue = Int64.MaxValue, UInt64 minValue = UInt64.MinValue)
                => Convert.ToUInt64(Math.Min(Math.Max(value, (long)minValue), maxValue));

            public static UInt64 ToUInt64(this Double value, Double maxValue = Double.MaxValue, UInt64 minValue = UInt64.MinValue)
                => Convert.ToUInt64(Math.Min(Math.Max(value, (double)minValue), maxValue));

            #region Nullable
            public static Boolean HasValue(this Nullable<UInt64> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<UInt64> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<UInt64> value, UInt64 otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<UInt64> value, UInt64 otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}