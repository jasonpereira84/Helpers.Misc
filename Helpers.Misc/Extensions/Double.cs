using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Double value, Double otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Double value, Double otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Double value, Double otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Double value, Double otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Double value, Double otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Double value)
                => value.Equals((Double)0);
            public static Boolean NotEqualsZero(this Double value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this Double value)
                => value.LessThan((Double)0);
            public static Boolean IsNotNegative(this Double value)
                => !value.IsNegative();
        }
    }
}