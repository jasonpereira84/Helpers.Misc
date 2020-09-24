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
            public static Boolean HasValue<T>(this Nullable<T> value)
                where T : struct 
                => value.HasValue;

            public static Boolean HasNoValue<T>(this Nullable<T> value)
                where T : struct 
                => !value.HasValue;

            public static Boolean HasValue<T>(this Nullable<T> value, out T sink, T defaultValue = default(T))
                where T : struct
            {
                sink = defaultValue;
                if (value.HasValue)
                {
                    sink = value.Value;
                    return true;
                }
                return false;
            }

            public static Boolean HasNoValue<T>(this Nullable<T> value, out T sink, T defaultValue = default(T))
                where T : struct
                => !HasValue(value, out sink, defaultValue);

            public static Boolean Equals<T>(this Nullable<T> value, T otherValue)
                where T : struct
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals<T>(this Nullable<T> value, T otherValue)
                where T : struct
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}