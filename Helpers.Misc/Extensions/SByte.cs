using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this SByte value, SByte otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this SByte value, SByte otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this SByte value, SByte otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this SByte value, SByte otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this SByte value, SByte otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this SByte value)
                => value.Equals((SByte)0);
            public static Boolean NotEqualsZero(this SByte value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this SByte value) 
                => value.LessThan((SByte)0);
            public static Boolean IsNotNegative(this SByte value) 
                => !value.IsNegative();
        }
    }
}