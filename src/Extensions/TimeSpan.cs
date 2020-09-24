using System;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean GreaterThan(this TimeSpan value, TimeSpan otherValue)
                => value > otherValue;

            public static Boolean GreaterThanOrEqualTo(this TimeSpan value, TimeSpan otherValue)
                => value.GreaterThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static Boolean LessThan(this TimeSpan value, TimeSpan otherValue)
                => value < otherValue;

            public static Boolean LessThanOrEqualTo(this TimeSpan value, TimeSpan otherValue)
                => value.LessThan(otherValue) ? true
                    : value.Equals(otherValue);

            public static TimeSpan RemainingTimeSpan(this UInt64 untilUnixtime, UInt64? currentUnixtime = null, Boolean ignoreNegative = true)
            {
                currentUnixtime = currentUnixtime ?? DateTime.UtcNow.ToUnixtime();

                var isGreater = untilUnixtime.GreaterThan(currentUnixtime.Value);
                Ensure.That<ArgumentOutOfRangeException>(isGreater || ignoreNegative,
                    $"{nameof(untilUnixtime)}<{untilUnixtime}> CANNOT be less than {nameof(currentUnixtime)}<{currentUnixtime.Value}>");

                var remainingSeconds = UInt64.MinValue;
                if (isGreater.IsTrue())
                    remainingSeconds = untilUnixtime - currentUnixtime.Value;

                return TimeSpan.FromSeconds(Convert.ToDouble(remainingSeconds));
            }

            public static String AsWords(this TimeSpan timeSpan,
                String format_Days = null,
                String format_Hours = null,
                String format_Minutes = null)
            {
                var dF = format_Days.SanitizeTo("{0} days");
                var hF = format_Hours.SanitizeTo("{0} hours");
                var mF = format_Minutes.SanitizeTo("{0} minutes");

                String str(Int32 d, Int32 h, Int32 m)
                {
                    return d.GreaterThan(0)
                      ? $"{String.Format(dF, d)} {str(0, h, m)}"
                      : h.GreaterThan(0)
                          ? $"{String.Format(hF, h)} {str(0, 0, m)}"
                          : m.LessThan(1) ? "" : String.Format(mF, m);
                }

                return str(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
            }

            #region Nullable
            public static Boolean HasValue(this Nullable<TimeSpan> value)
                => value.HasValue;

            public static Boolean HasNoValue(this Nullable<TimeSpan> value)
                => !value.HasValue;

            public static Boolean Equals(this Nullable<TimeSpan> value, TimeSpan otherValue)
                => value.HasValue() && value.Equals(otherValue);

            public static Boolean NotEquals(this Nullable<TimeSpan> value, TimeSpan otherValue)
                => value.HasValue() && !value.Equals(otherValue);
            #endregion Nullable
        }
    }
}