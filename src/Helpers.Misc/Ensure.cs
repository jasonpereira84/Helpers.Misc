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
            public static void Is(Boolean predicate, String message, String paramName) => _that(predicate, () => new ArgumentException(message ?? "NULL message", paramName?.Trim() ?? "NotSpecified"));

            public static void IsNot(Boolean predicate) => Is(!predicate);
            public static void IsNot(Boolean predicate, String message) => Is(!predicate, message);
            public static void IsNot(Boolean predicate, String message, String paramName) => Is(!predicate, message, paramName);


            public static void IsNull(Object value) => Is(value == null);
            public static void IsNull(Object value, String message) => Is(value == null, message);
            public static void IsNull(Object value, String message, String paramName) => Is(value == null, message, paramName);

            public static void IsNotNull(Object value) => Is(value != null);
            public static void IsNotNull(Object value, String message) => Is(value != null, message);
            public static void IsNotNull(Object value, String message, String paramName) => Is(value != null, message, paramName);

            #region String
            public static void IsNotNullOrEmptyOrWhiteSpace(String @string) => IsNot(String.IsNullOrWhiteSpace(@string));
            public static void IsNotNullOrEmptyOrWhiteSpace(String @string, String message) => IsNot(String.IsNullOrWhiteSpace(@string), message);
            public static void IsNotNullOrEmptyOrWhiteSpace(String @string, String message, String paramName) => IsNot(String.IsNullOrWhiteSpace(@string), message, paramName);
            #endregion String

            #region IEnumerable
            public static void IsNotNullOrNone<TSource>(IEnumerable<TSource> source) => Is(!_internalHelpers.IsNullOrNone(source));
            public static void IsNotNullOrNone<TSource>(IEnumerable<TSource> source, String message) => Is(_internalHelpers.IsNullOrNone(source), message);
            public static void IsNotNullOrNone<TSource>(IEnumerable<TSource> source, String message, String paramName) => Is(!_internalHelpers.IsNullOrNone(source), message, paramName);
            #endregion IEnumerable
        }
    }
}
