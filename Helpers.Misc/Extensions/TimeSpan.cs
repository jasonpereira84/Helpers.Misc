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

            public static Boolean EqualsZero(this TimeSpan value)
                => value.Equals(TimeSpan.Zero);
            public static Boolean NotEqualsZero(this TimeSpan value)
                => !value.EqualsZero();

            public static Boolean IsNegative(this TimeSpan value)
                => value.LessThan(TimeSpan.Zero);
            public static Boolean IsNotNegative(this TimeSpan value)
                => !value.IsNegative();

            public static TimeSpan RemainingTimeSpan(this UInt64 secondsUntil, UInt64 currentUnixTime, Boolean ignoreNegative = false)
            {
                var secondsUntilGreaterThanCurrentUnixTime = secondsUntil.GreaterThanOrEqualTo(currentUnixTime);
                if (secondsUntilGreaterThanCurrentUnixTime.IsFalse() && ignoreNegative.IsFalse())
                    throw new ArgumentOutOfRangeException(nameof(secondsUntil), $"{nameof(secondsUntil)}<{secondsUntil}> CANNOT be less than {nameof(currentUnixTime)}<{currentUnixTime}>");

                return TimeSpan.FromSeconds(
                    secondsUntilGreaterThanCurrentUnixTime
                        ? Convert.ToDouble(secondsUntil - currentUnixTime)
                        : -Convert.ToDouble(currentUnixTime - secondsUntil));
            }
            public static TimeSpan RemainingTimeSpan(this UInt64 secondsUntilCurrentUnixTime, Boolean ignoreNegative = false)
                => secondsUntilCurrentUnixTime.RemainingTimeSpan(DateTime.UtcNow.AsUnixTime(), ignoreNegative);

            public static String AsWords(this TimeSpan timeSpan,
                String format_Days = default,
                String format_Hours = default,
                String format_Minutes = default,
                String format_Seconds = default)
            {
                var dF = format_Days.SanitizeTo("{0} days");
                var hF = format_Hours.SanitizeTo("{0} hours");
                var mF = format_Minutes.SanitizeTo("{0} minutes");
                var sF = format_Seconds.SanitizeTo("{0} seconds");

                String str(Int32 d, Int32 h, Int32 m, Int32 s)
                {
                    return d.GreaterThan(0)
                      ? $"{String.Format(dF, d)} {str(0, h, m, s)}"
                      : h.GreaterThan(0)
                          ? $"{String.Format(hF, h)} {str(0, 0, m, s)}"
                          : m.GreaterThan(0)
                              ? $"{String.Format(mF, m)} {str(0, 0, 0, s)}"
                              : String.Format(sF, s);
                }
                return str(timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }

        }
    }
}