using System;

namespace JasonPereira84.Helpers
{
    public class DateNotFoundException : Exception
    {
        public DateNotFoundException(MonthsOfYear monthOfYear, Int32 year, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek)
            : this($"{monthOfYear} of {year} does NOT-CONTAIN a {weekOfMonth}-{dayOfWeek}")
        { }

        public DateNotFoundException(Int32 year, WeekOfYear weekOfYear, DayOfWeek dayOfWeek)
            : this($"The year<{year}> does NOT-CONTAIN a {weekOfYear}-{dayOfWeek}")
        { }

        private DateNotFoundException() : base() { }
        private DateNotFoundException(String message) : base(message) { }
        private DateNotFoundException(String message, Exception innerException) : base(message, innerException) { }

    }
}