using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static DateTime Epoch => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            public static DateTime ToDateTimeUTC(this UInt64 value)
                => new DateTime(TimeSpan.FromSeconds(value).Ticks);

            public static UInt64 ToUnixtime(this DateTime valueUTC)
                => (valueUTC - Epoch).TotalSeconds.ToUInt64();

            #region Nullable
            public static Boolean HasValue(this Nullable<DateTime> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<DateTime> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<DateTime> value, DateTime otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<DateTime> value, DateTime otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}