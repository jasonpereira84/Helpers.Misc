using System;

namespace JasonPereira84.Helpers
{
    internal static partial class _internalHelpers
    {
        public static Boolean IsNull(this String value)
            => value == null;

        public static Boolean IsEmpty(this String value)
            => value?.Length.Equals(0) ?? false;

        public static Boolean IsWhiteSpace(this String value)
            => !value.IsEmpty() && (value?.Trim().Length.Equals(0) ?? false);

        public static Boolean IsNullOrEmpty(this String value)
            => value.IsNull() || value.IsEmpty();

        public static Boolean IsEmptyOrWhiteSpace(this String value)
            => value.IsEmpty() || value.IsWhiteSpace();

        public static Boolean IsNullOrEmptyOrWhiteSpace(this String value)
            => String.IsNullOrWhiteSpace(value);

        public static (Boolean IsSane, String Value) EvaluateSanity(this String value,
            String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
            => IsNull(value)
                ? (false, valueIfNull)
                : IsEmpty(value)
                    ? (false, valueIfEmpty)
                    : IsWhiteSpace(value)
                        ? (false, valueIfWhitespace)
                        : (true, dontTrim ? value : value.Trim());
        public static (Boolean IsSane, String Value) EvaluateSanity(this String value,
            out (Boolean IsSane, String Value) result,
            String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
            => result = EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);

        public static Boolean EvaluateSanity(this String value, out String saneValue, Boolean dontTrim = false)
        {
            var result = EvaluateSanity(value, $"NULL", $"EMPTY", $"WHITESPACE", dontTrim);
            saneValue = result.Value;
            return result.IsSane;
        }

        public static Boolean EvaluateSanity(this String value, String name, out String saneValue, Boolean dontTrim = false)
        {
            var result = EvaluateSanity(value, $"NULL-{name}", $"EMPTY-{name}", $"WHITESPACE-{name}", dontTrim);
            saneValue = result.Value;
            return result.IsSane;
        }

        public static String SanitizeTo(this String value, String valueIfNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            => String.IsNullOrWhiteSpace(value)
                ? valueIfNullOrEmptyOrWhiteSpace
                : dontTrim
                    ? value
                    : value.Trim();

        public static String Sanitize(this String value, 
            String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
            => EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim).Value;
        public static String Sanitize(this String value, String name,
            String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
            => EvaluateSanity(value, $"{valueIfNull}-{name}", $"{valueIfEmpty}-{name}", $"{valueIfWhitespace}-{name}", dontTrim).Value;

    }
}
