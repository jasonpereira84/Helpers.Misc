using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean NotEquals<T>(this T value, T otherValue) 
                where T : struct 
                => !value.Equals(otherValue);

            #region Nullable
            public static Boolean NotHasValue<T>(this Nullable<T> value)
                where T : struct 
                => !value.HasValue;
            #endregion Nullable
        }
    }
}