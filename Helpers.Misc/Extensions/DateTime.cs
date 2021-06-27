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

            #region Of
            private static DateTime firstDayOfMonth(Int32 year, Int32 month, DateTimeKind dateTimeKind)
                => new DateTime(year, month, 1, 0, 0, 0, dateTimeKind);
            private static DateTime firstDayOfMonth(Int32 monthOfYear, Int32 year)
                => firstDayOfMonth(year, monthOfYear, DateTimeKind.Utc);

            public static DateTime FirstDayOfMonth(this Int32 year, MonthsOfYear month, DateTimeKind dateTimeKind)
                => firstDayOfMonth(year > 0 ? year : throw new ArgumentOutOfRangeException(nameof(year)), (Int32)month, dateTimeKind);
            public static DateTime FirstDayOfMonth(this MonthsOfYear monthOfYear, Int32 year)
                => firstDayOfMonth((Int32)monthOfYear, year > 0 ? year : throw new ArgumentOutOfRangeException(nameof(year)));

            public static DateTime FirstDayOfJanuary(this Int32 year) => FirstDayOfMonth(MonthsOfYear.January, year);
            public static DateTime FirstDayOfFebruary(this Int32 year) => FirstDayOfMonth(MonthsOfYear.February, year);
            public static DateTime FirstDayOfMarch(this Int32 year) => FirstDayOfMonth(MonthsOfYear.March, year);
            public static DateTime FirstDayOfApril(this Int32 year) => FirstDayOfMonth(MonthsOfYear.April, year);
            public static DateTime FirstDayOfMay(this Int32 year) => FirstDayOfMonth(MonthsOfYear.May, year);
            public static DateTime FirstDayOfJune(this Int32 year) => FirstDayOfMonth(MonthsOfYear.June, year);
            public static DateTime FirstDayOfJuly(this Int32 year) => FirstDayOfMonth(MonthsOfYear.July, year);
            public static DateTime FirstDayOfAugust(this Int32 year) => FirstDayOfMonth(MonthsOfYear.August, year);
            public static DateTime FirstDayOfSeptember(this Int32 year) => FirstDayOfMonth(MonthsOfYear.September, year);
            public static DateTime FirstDayOfOctober(this Int32 year) => FirstDayOfMonth(MonthsOfYear.October, year);
            public static DateTime FirstDayOfNovember(this Int32 year) => FirstDayOfMonth(MonthsOfYear.November, year);
            public static DateTime FirstDayOfDecember(this Int32 year) => FirstDayOfMonth(MonthsOfYear.December, year);

            private static DateTime firstWeekdayOfMonth(DateTime firstDayOfMonth, DayOfWeek dayOfWeek)
                => firstDayOfMonth.AddDays(
                    (dayOfWeek - firstDayOfMonth.DayOfWeek)
                    .If(value => value.IsNegative(),
                        value => value + 7));

            public static DateTime FirstWeekdayOfMonth(this MonthsOfYear monthOfYear, Int32 year, DayOfWeek dayOfWeek)
                => firstWeekdayOfMonth(FirstDayOfMonth(monthOfYear, year), dayOfWeek);
            public static DateTime FirstSundayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Sunday);
            public static DateTime FirstMondayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Monday);
            public static DateTime FirstTuesdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Tuesday);
            public static DateTime FirstWednesdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Wednesday);
            public static DateTime FirstThursdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Thursday);
            public static DateTime FirstFridayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Friday);
            public static DateTime FirstSaturdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => FirstWeekdayOfMonth(monthOfYear, year, DayOfWeek.Saturday);

            public static DateTime LastWeekdayOfMonth(this MonthsOfYear monthOfYear, Int32 year, DayOfWeek dayOfWeek)
            {
                year = year > 0 ? year : throw new ArgumentOutOfRangeException(nameof(year));

                var firstDayOfNextMonth = monthOfYear.NotEquals(MonthsOfYear.December)
                    ? firstDayOfMonth((Int32)monthOfYear + 1, year)
                    : firstDayOfMonth((Int32)MonthsOfYear.January, year + 1);
                var firstWeekdayOfNextMonth = firstWeekdayOfMonth(firstDayOfNextMonth, dayOfWeek);

                return firstWeekdayOfNextMonth.AddDays(-7);
            }
            public static DateTime LastSundayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Sunday);
            public static DateTime LastMondayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Monday);
            public static DateTime LastTuesdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Tuesday);
            public static DateTime LastWednesdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Wednesday);
            public static DateTime LastThursdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Thursday);
            public static DateTime LastFridayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Friday);
            public static DateTime LastSaturdayOfMonth(this MonthsOfYear monthOfYear, Int32 year) => LastWeekdayOfMonth(monthOfYear, year, DayOfWeek.Saturday);


            public static DateTime DayOfMonth(this MonthsOfYear monthOfYear, Int32 year, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, Boolean dontThrowException = false)
            {
                var retVal = FirstWeekdayOfMonth(monthOfYear, year, dayOfWeek);
                {
                    var monthNum = (Int32)monthOfYear;
                    var repetitions = (Int32)weekOfMonth;
                    while (repetitions-- > 1)// '1' since we are alredy on First Week
                    {
                        retVal = retVal.AddDays(7);
                        if (retVal.Month.NotEquals(monthNum))
                        {
                            if (dontThrowException)
                                return retVal.AddDays(-7);

                            throw new DateNotFoundException(monthOfYear, year, weekOfMonth, dayOfWeek);
                        }
                    }
                }
                return retVal;
            }
            public static DateTime SundayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Sunday, dontThrowException);
            public static DateTime MondayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Monday, dontThrowException);
            public static DateTime TuesdayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Tuesday, dontThrowException);
            public static DateTime WednesdayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Wednesday, dontThrowException);
            public static DateTime ThursdayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Thursday, dontThrowException);
            public static DateTime FridayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Friday, dontThrowException);
            public static DateTime SaturdayOfMonth(this MonthsOfYear monthOfYear, Int32 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Saturday, dontThrowException);

            public static DateTime DayOfYear(this Int32 year, WeekOfYear weekOfYear, DayOfWeek dayOfWeek, Boolean dontThrowException = false)
            {
                DateTime _dayOfYear(Int32 repetitions, Boolean dontThrow)
                {
                    var retVal = FirstWeekdayOfMonth(MonthsOfYear.January, year, dayOfWeek);
                    {
                        while (repetitions-- > 0)
                        {
                            retVal = retVal.AddDays(7);
                            if (retVal.Year.NotEquals(year))
                            {
                                if (dontThrow)
                                    return retVal.AddDays(-7);

                                throw new DateNotFoundException(year, weekOfYear, dayOfWeek);
                            }
                        }
                    }
                    return retVal;
                }
                return weekOfYear.Equals(WeekOfYear.Last)
                    ? _dayOfYear((Int32)WeekOfYear.FiftyThird, true)
                    : _dayOfYear((Int32)weekOfYear, dontThrowException);
            }
            #endregion Of
        }
    }
}