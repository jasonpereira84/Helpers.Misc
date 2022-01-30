using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals(this Byte value, Byte otherValue)
                => !value.Equals(otherValue);

            public static Boolean GreaterThan(this Byte value, Byte otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this Byte value, Byte otherValue)
                => value.GreaterThan(otherValue) || value.Equals(otherValue);

            public static Boolean LessThan(this Byte value, Byte otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this Byte value, Byte otherValue)
                => value.LessThan(otherValue) || value.Equals(otherValue);

            public static Boolean EqualsZero(this Byte value) 
                => value.Equals((Byte)0);
            public static Boolean NotEqualsZero(this Byte value) 
                => !value.EqualsZero();

        }
    }
}