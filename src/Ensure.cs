using System;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    public static partial class Ensure
    {
        private static void _that<TException>(Boolean p, Func<TException> fx)
            where TException : Exception
        { if (!p) throw fx(); }

        public static void That<TException>(Boolean predicate)
            where TException : Exception 
            => _that(predicate, () => (TException)Activator.CreateInstance(typeof(TException)));
        public static void That<TException>(Boolean predicate, Object[] args)
            where TException : Exception
            => _that(predicate, () => (TException)Activator.CreateInstance(typeof(TException), args ?? new Object[0]));
        public static void That<TException>(Boolean predicate, String message)
            where TException : Exception
            => That<TException>(predicate, new Object[] { message ?? "NULL message" });

        public static void That(Boolean predicate) => That<Exception>(predicate);
        public static void That(Boolean predicate, String message) => That<Exception>(predicate, message);

        public static class Argument
        {
            public static void Is(Boolean predicate) => _that(predicate, () => new ArgumentException());
            public static void Is(Boolean predicate, String message) => _that(predicate, () => new ArgumentException(message ?? "NULL message"));
            public static void Is(Boolean predicate, String message, String paramName) => _that(predicate, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            public static void IsNot(Boolean predicate) => Is(!predicate);
            public static void IsNot(Boolean predicate, String message) => Is(!predicate, message);
            public static void IsNot(Boolean predicate, String message, String paramName) => Is(!predicate, message, paramName);

            public static void Is(Object value, String paramName, Boolean predicate)
            {
                paramName = paramName?.Trim() ?? "NotSpecified";
                _that(predicate, () => new ArgumentException($"The argument<{paramName}> was NOT-NULL", paramName));
            }

            public static void IsNull(Object value, String paramName)
                => Is(value, paramName, value == null);

            public static void IsNotNull(Object value, String paramName)
                => Is(value, paramName, value != null);

            public static void IsNotNullOrNone<TSource>(IEnumerable<TSource> source) => Is(Extensions.Misc.IsNotNullOrNone(source));
            public static void IsNotNullOrNone<TSource>(IEnumerable<TSource> source, String message) => Is(Extensions.Misc.IsNotNullOrNone(source), message);
            public static void IsNotNullOrNone<TSource>(IEnumerable<TSource> source, String message, String paramName) => Is(Extensions.Misc.IsNotNullOrNone(source), message, paramName);
        }

        public static class String2
        {
            private static void _isNull(String s, Func<ArgumentException> fxX) => _that(s == null, fxX);
            public static void IsNull(String string_) => _isNull(string_, () => new ArgumentException());
            public static void IsNull(String string_, String message) => _isNull(string_, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNull(String string_, String message, String paramName) => _isNull(string_, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            private static void _isNotNull(String s, Func<ArgumentException> fxX) => _that(s != null, fxX);
            public static void IsNotNull(String string_) => _isNotNull(string_, () => new ArgumentException());
            public static void IsNotNull(String string_, String message) => _isNotNull(string_, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNotNull(String string_, String message, String paramName) => _isNotNull(string_, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));


            private static void _isEmpty(String s, Func<ArgumentException> fxX) => _that(s.Length == 0, fxX);
            public static void IsEmpty(String nonNullString) => _isEmpty(nonNullString, () => new ArgumentException());
            public static void IsEmpty(String nonNullString, String message) => _isEmpty(nonNullString, () => new ArgumentException(message ?? "NULL message"));
            public static void IsEmpty(String nonNullString, String message, String paramName) => _isEmpty(nonNullString, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            private static void _isNotEmpty(String s, Func<ArgumentException> fxX) => _that(s.Length != 0, fxX);
            public static void IsNotEmpty(String nonNullString) => _isNotEmpty(nonNullString, () => new ArgumentException());
            public static void IsNotEmpty(String nonNullString, String message) => _isNotEmpty(nonNullString, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNotEmpty(String nonNullString, String message, String paramName) => _isNotEmpty(nonNullString, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));


            private static void _isWhiteSpace(String s, Func<ArgumentException> fxX) => _that(s.Trim().Length == 0, fxX);
            public static void IsWhiteSpace(String nonNullString) => _isWhiteSpace(nonNullString, () => new ArgumentException());
            public static void IsWhiteSpace(String nonNullString, String message) => _isWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message"));
            public static void IsWhiteSpace(String nonNullString, String message, String paramName) => _isWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            private static void _isNotWhiteSpace(String s, Func<ArgumentException> fxX) => _that(s.Trim().Length != 0, fxX);
            public static void IsNotWhiteSpace(String nonNullString) => _isNotWhiteSpace(nonNullString, () => new ArgumentException());
            public static void IsNotWhiteSpace(String nonNullString, String message) => _isNotWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNotWhiteSpace(String nonNullString, String message, String paramName) => _isNotWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));


            private static void _isNullOrEmpty(String s, Func<ArgumentException> fxX) => _that((s == null) || (s.Length == 0), fxX);
            public static void IsNullOrEmpty(String string_) => _isNullOrEmpty(string_, () => new ArgumentException());
            public static void IsNullOrEmpty(String string_, String message) => _isNullOrEmpty(string_, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNullOrEmpty(String string_, String message, String paramName) => _isNullOrEmpty(string_, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            private static void _isNotNullOrEmpty(String s, Func<ArgumentException> fxX) => _that((s != null) && (s.Length != 0), fxX);
            public static void IsNotNullOrEmpty(String string_) => _isNotNullOrEmpty(string_, () => new ArgumentException());
            public static void IsNotNullOrEmpty(String string_, String message) => _isNotNullOrEmpty(string_, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNotNullOrEmpty(String string_, String message, String paramName) => _isNotNullOrEmpty(string_, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));


            private static void _isEmptyOrWhiteSpace(String s, Func<ArgumentException> fxX) => _that((s.Length == 0) || (s.Trim().Length == 0), fxX);
            public static void IsEmptyOrWhiteSpace(String nonNullString) => _isEmptyOrWhiteSpace(nonNullString, () => new ArgumentException());
            public static void IsEmptyOrWhiteSpace(String nonNullString, String message) => _isEmptyOrWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message"));
            public static void IsEmptyOrWhiteSpace(String nonNullString, String message, String paramName) => _isEmptyOrWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            private static void _isNotEmptyOrWhiteSpace(String s, Func<ArgumentException> fxX) => _that((s.Length != 0) && (s.Trim().Length != 0), fxX);
            public static void IsNotEmptyOrWhiteSpace(String nonNullString) => _isNotEmptyOrWhiteSpace(nonNullString, () => new ArgumentException());
            public static void IsNotEmptyOrWhiteSpace(String nonNullString, String message) => _isNotEmptyOrWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNotEmptyOrWhiteSpace(String nonNullString, String message, String paramName) => _isNotEmptyOrWhiteSpace(nonNullString, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));


            private static void _isNullOrEmptyOrWhiteSpace(String s, Func<ArgumentException> fxX) => _that((s == null) || (s.Length == 0) || (s.Trim().Length == 0), fxX);
            public static void IsNullOrEmptyOrWhiteSpace(String string_) => _isNullOrEmptyOrWhiteSpace(string_, () => new ArgumentException());
            public static void IsNullOrEmptyOrWhiteSpace(String string_, String message) => _isNullOrEmptyOrWhiteSpace(string_, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNullOrEmptyOrWhiteSpace(String string_, String message, String paramName) => _isNullOrEmptyOrWhiteSpace(string_, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));

            private static void _isNotNullOrEmptyOrWhiteSpace(String s, Func<ArgumentException> fxX) => _that((s != null) && (s.Length != 0) && (s.Trim().Length != 0), fxX);
            public static void IsNotNullOrEmptyOrWhiteSpace(String string_) => _isNotNullOrEmptyOrWhiteSpace(string_, () => new ArgumentException());
            public static void IsNotNullOrEmptyOrWhiteSpace(String string_, String message) => _isNotNullOrEmptyOrWhiteSpace(string_, () => new ArgumentException(message ?? "NULL message"));
            public static void IsNotNullOrEmptyOrWhiteSpace(String string_, String message, String paramName) => _isNotNullOrEmptyOrWhiteSpace(string_, () => new ArgumentException(message ?? "NULL message", paramName ?? "NotSpecified"));
        }

    }
}
