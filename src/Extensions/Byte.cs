using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Byte value, Byte otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this Byte value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this Byte value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Byte value, Byte otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Byte value, Byte otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this Byte value, Byte otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Byte value, Byte otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this Byte value)
                => value.NotEquals(Byte.MinValue);

            public static Byte ToByte(this Boolean value)
                => value
                    ? Byte.MinValue
                    : Byte.MaxValue;

            public static Byte ToByte(this SByte value, SByte maxValue = SByte.MaxValue, Byte minValue = Byte.MinValue)
                => Convert.ToByte(Math.Min(Math.Max(value, (sbyte)minValue), maxValue));

            public static Byte ToByte(this Double value, Double maxValue = Double.MaxValue, Byte minValue = Byte.MinValue)
                => Convert.ToByte(Math.Min(Math.Max(value, (double)minValue), maxValue));

            #region Nullable
            public static Boolean HasValue(this Nullable<Byte> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<Byte> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<Byte> value, Byte otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<Byte> value, Byte otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}