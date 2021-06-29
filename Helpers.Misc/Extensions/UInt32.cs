using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this UInt32 value, UInt32 otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this UInt32 value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this UInt32 value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this UInt32 value, UInt32 otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this UInt32 value, UInt32 otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this UInt32 value, UInt32 otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this UInt32 value, UInt32 otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this UInt32 value)
                => value.NotEquals(UInt32.MinValue);

            public static UInt32 ToUInt32(this Boolean value)
                => value
                    ? UInt32.MinValue
                    : UInt32.MaxValue;

            public static UInt32 ToUInt32(this Int32 value, Int32 maxValue = Int32.MaxValue, UInt32 minValue = UInt32.MinValue)
                => Convert.ToUInt32(Math.Min(Math.Max(value, (int)minValue), maxValue));

            public static UInt32 ToUInt32(this Double value, Double maxValue = Double.MaxValue, UInt32 minValue = UInt32.MinValue)
                => Convert.ToUInt32(Math.Min(Math.Max(value, (double)minValue), maxValue));
        }
    }
}