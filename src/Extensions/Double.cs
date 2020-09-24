using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Double value, Double otherValue)
            => !value.Equals(otherValue);

            public static Boolean Equals<TEnum>(this Double value, TEnum otherValue)
                where TEnum : struct
                => value.Equals(otherValue);

            public static Boolean NotEquals<TEnum>(this Double value, TEnum otherValue)
                where TEnum : struct
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Double value, Double otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Double value, Double otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this Double value, Double otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Double value, Double otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean ToBoolean(this Double value)
                => value.NotEquals(Double.MinValue);

            public static Double ToDouble(this Boolean value)
                => value
                    ? Double.MinValue
                    : Double.MaxValue;

            #region Nullable
            public static Boolean HasValue(this Nullable<Double> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<Double> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<Double> value, Double otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<Double> value, Double otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}