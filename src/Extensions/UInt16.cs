using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this UInt16 value, UInt16 otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this UInt16 value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this UInt16 value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this UInt16 value, UInt16 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this UInt16 value, UInt16 otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this UInt16 value, UInt16 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this UInt16 value, UInt16 otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this UInt16 value)
                => value.NotEquals(UInt16.MinValue);

            public static UInt16 ToUInt16(this Boolean value)
                => value
                    ? UInt16.MinValue
                    : UInt16.MaxValue;

            public static UInt16 ToUInt16(this Int16 value, Int16 maxValue = Int16.MaxValue, UInt16 minValue = UInt16.MinValue)
                => Convert.ToUInt16(Math.Min(Math.Max(value, (short)minValue), maxValue));

            public static UInt16 ToUInt16(this Double value, Double maxValue = Double.MaxValue, UInt16 minValue = UInt16.MinValue)
                => Convert.ToUInt16(Math.Min(Math.Max(value, (double)minValue), maxValue));

            #region Nullable
            public static Boolean HasValue(this Nullable<UInt16> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<UInt16> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<UInt16> value, UInt16 otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<UInt16> value, UInt16 otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}