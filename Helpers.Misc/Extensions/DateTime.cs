using System;
using System.Globalization;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static DateTime AsDateTimeUTC(this UInt64 value)
                => new DateTime(TimeSpan.FromSeconds(value).Ticks);

            public static UInt64 AsUnixTime(this DateTime dateTimeUTC)
                => Convert.ToUInt64((dateTimeUTC - DateTime.UnixEpoch).TotalSeconds);

            public static UInt64 AsUnixTime(this DateTimeOffset dateTimeOffset)
                => dateTimeOffset.UtcDateTime.AsUnixTime();

            #region Of
            private static DateTime firstDayOfMonth(Int32 year, Int32 month, DateTimeKind dateTimeKind)
                => new DateTime(year, month, 1, 0, 0, 0, dateTimeKind);

            public static DateTime FirstDayOfMonth(this UInt16 year, MonthsOfYear month, DateTimeKind dateTimeKind)
                 => firstDayOfMonth(year > 0 ? year : throw new ArgumentOutOfRangeException(nameof(year)), (Int32)month, dateTimeKind);

            private static DateTime firstDayOfMonth(Int32 monthOfYear, Int32 year)
                => firstDayOfMonth(year, monthOfYear, DateTimeKind.Utc);

            public static DateTime FirstDayOfMonth(this MonthsOfYear monthOfYear, UInt16 year)
                => firstDayOfMonth((Int32)monthOfYear, year > 0 ? year : throw new ArgumentOutOfRangeException(nameof(year)));           
            public static DateTime FirstDayOfJanuary(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.January, year);
            public static DateTime FirstDayOfFebruary(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.February, year);
            public static DateTime FirstDayOfMarch(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.March, year);
            public static DateTime FirstDayOfApril(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.April, year);
            public static DateTime FirstDayOfMay(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.May, year);
            public static DateTime FirstDayOfJune(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.June, year);
            public static DateTime FirstDayOfJuly(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.July, year);
            public static DateTime FirstDayOfAugust(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.August, year);
            public static DateTime FirstDayOfSeptember(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.September, year);
            public static DateTime FirstDayOfOctober(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.October, year);
            public static DateTime FirstDayOfNovember(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.November, year);
            public static DateTime FirstDayOfDecember(this UInt16 year) 
                => FirstDayOfMonth(MonthsOfYear.December, year);

            private static DateTime firstDayOfWeekOfMonth(DateTime firstDayOfMonth, DayOfWeek dayOfWeek)
                => firstDayOfMonth.AddDays(
                    (dayOfWeek - firstDayOfMonth.DayOfWeek)
                    .If(value => value.IsNegative(),
                        value => value + 7));

            public static DateTime FirstDayOfWeekOfMonth(this MonthsOfYear monthOfYear, UInt16 year, DayOfWeek dayOfWeek)
                => firstDayOfWeekOfMonth(FirstDayOfMonth(monthOfYear, year), dayOfWeek);
            public static DateTime FirstSundayOfMonth(this MonthsOfYear monthOfYear, UInt16 year)
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Sunday);
            public static DateTime FirstMondayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Monday);
            public static DateTime FirstTuesdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Tuesday);
            public static DateTime FirstWednesdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Wednesday);
            public static DateTime FirstThursdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Thursday);
            public static DateTime FirstFridayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Friday);
            public static DateTime FirstSaturdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => monthOfYear.FirstDayOfWeekOfMonth(year, DayOfWeek.Saturday);

            public static DateTime LastDayOfWeekOfMonth(this MonthsOfYear monthOfYear, UInt16 year, DayOfWeek dayOfWeek)
            {
                year = year > 0 ? year : throw new ArgumentOutOfRangeException(nameof(year));

                var firstDayOfNextMonth = monthOfYear.NotEquals(MonthsOfYear.December)
                    ? firstDayOfMonth((Int32)monthOfYear + 1, year)
                    : firstDayOfMonth((Int32)MonthsOfYear.January, year + 1);
                var firstWeekdayOfNextMonth = firstDayOfWeekOfMonth(firstDayOfNextMonth, dayOfWeek);

                return firstWeekdayOfNextMonth.AddDays(-7);
            }
            public static DateTime LastSundayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Sunday);
            public static DateTime LastMondayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Monday);
            public static DateTime LastTuesdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Tuesday);
            public static DateTime LastWednesdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Wednesday);
            public static DateTime LastThursdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Thursday);
            public static DateTime LastFridayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Friday);
            public static DateTime LastSaturdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year) 
                => LastDayOfWeekOfMonth(monthOfYear, year, DayOfWeek.Saturday);

            public static DateTime DayOfMonth(this MonthsOfYear monthOfYear, UInt16 year, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, Boolean dontThrowException = false)
            {
                var retVal = FirstDayOfWeekOfMonth(monthOfYear, year, dayOfWeek);
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
            public static DateTime SundayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Sunday, dontThrowException);
            public static DateTime MondayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Monday, dontThrowException);
            public static DateTime TuesdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Tuesday, dontThrowException);
            public static DateTime WednesdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Wednesday, dontThrowException);
            public static DateTime ThursdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Thursday, dontThrowException);
            public static DateTime FridayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Friday, dontThrowException);
            public static DateTime SaturdayOfMonth(this MonthsOfYear monthOfYear, UInt16 year,  WeekOfMonth weekOfMonth, Boolean dontThrowException = false) 
                => DayOfMonth(monthOfYear, year, weekOfMonth, DayOfWeek.Saturday, dontThrowException);

            public static DateTime DayOfYear(this UInt16 year, WeekOfYear weekOfYear, DayOfWeek dayOfWeek, CultureInfo cultureInfo, Boolean dontThrowException = false)
            {
                if (cultureInfo == null)
                    throw new ArgumentNullException(nameof(cultureInfo));

                var calendar = cultureInfo.Calendar;
                DateTime _dayOfYear(Int32 repetitions, Boolean dontThrow)
                {
                    var retVal = FirstDayOfWeekOfMonth(MonthsOfYear.January, year, dayOfWeek);
                    {
                        while (repetitions-- > 0)
                        {
                            var woy = calendar.GetWeekOfYear(retVal, cultureInfo.DateTimeFormat.CalendarWeekRule, cultureInfo.DateTimeFormat.FirstDayOfWeek);
                            if (woy.Equals((Int32)weekOfYear))
                                return retVal;

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
            public static DateTime DayOfYear(this UInt16 year, WeekOfYear weekOfYear, DayOfWeek dayOfWeek, Boolean dontThrowException = false)
                => year.DayOfYear(weekOfYear, dayOfWeek, new CultureInfo("en-US"), dontThrowException);
            #endregion Of
        }
    }
}