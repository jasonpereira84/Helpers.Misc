using System;
using System.Text;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean IsNull(this String value) => _internalHelpers.IsNull(value);
            public static Boolean IsNotNull(this String value) => !_internalHelpers.IsNull(value);

            public static Boolean IsEmpty(this String value) => _internalHelpers.IsEmpty(value);
            public static Boolean IsNotEmpty(this String value) => !_internalHelpers.IsEmpty(value);

            public static Boolean IsWhiteSpace(this String value) => _internalHelpers.IsWhiteSpace(value);
            public static Boolean IsNotWhiteSpace(this String value) => !_internalHelpers.IsWhiteSpace(value);

            public static Boolean IsNullOrEmpty(this String value) => _internalHelpers.IsNullOrEmpty(value);
            public static Boolean IsNotNullOrEmpty(this String value) => !_internalHelpers.IsNullOrEmpty(value);

            public static Boolean IsEmptyOrWhiteSpace(this String value) => _internalHelpers.IsEmptyOrWhiteSpace(value);
            public static Boolean IsNotEmptyOrWhiteSpace(this String value) => !_internalHelpers.IsEmptyOrWhiteSpace(value);

            public static Boolean IsNullOrEmptyOrWhiteSpace(this String value) => _internalHelpers.IsNullOrEmptyOrWhiteSpace(value);
            public static Boolean IsNotNullOrEmptyOrWhiteSpace(this String value) => !_internalHelpers.IsNullOrEmptyOrWhiteSpace(value);

            public static (Boolean IsSane, String Value) EvaluateSanity(this String value, 
                String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
                => _internalHelpers.EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);
            public static (Boolean IsSane, String Value) EvaluateSanity(this String value,
                out (Boolean IsSane, String Value) result,
                String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
                => _internalHelpers.EvaluateSanity(value, out result, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);

            public static Boolean EvaluateSanity(this String value, out String saneValue, Boolean dontTrim = false)
                => _internalHelpers.EvaluateSanity(value, out saneValue, dontTrim);

            public static Boolean EvaluateSanity(this String value, String name, out String saneValue, Boolean dontTrim = false)
                => _internalHelpers.EvaluateSanity(value, name, out saneValue, dontTrim);

            public static String SanitizeTo(this String value, String valueIfNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
                => _internalHelpers.SanitizeTo(value, valueIfNullOrEmptyOrWhiteSpace, dontTrim);

            public static String Sanitize(this String value,
                String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
                => _internalHelpers.Sanitize(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);
            public static String Sanitize(this String value, String name,
                String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
                => _internalHelpers.Sanitize(value, $"{valueIfNull}-{name}", $"{valueIfEmpty}-{name}", $"{valueIfWhitespace}-{name}", dontTrim);


            public static Boolean Matches(this String value, String otherValue) => value.Equals(otherValue, StringComparison.OrdinalIgnoreCase);

            public static String SurroundWith(this String value, String @string) => $"{@string}{value}{@string}";
            public static String SurroundWith(this String value, Char @char) => $"{@char}{value}{@char}";

            public static String QuoteSINGLE(this String value) => SurroundWith(value, "'");

            public static String QuoteDOUBLE(this String value) => SurroundWith(value, '"');

            public static String MaskWith(this String value, Int32 length, Char @char)
            {
                var masked = new String(@char, length);
                return length.Equals(value.Length) ? masked
                    : masked + value.Substring(9, value.Length - length);
            }

            public static String Mask(this String value, Char @char = '*') => new String(@char, value.Length);

            public static void IfNotNullOrEmptyOrWhiteSpace(this String value, Action<String> actionIfTrue, Boolean dontTrim = false)
            {
                if (!String.IsNullOrWhiteSpace(value))
                    actionIfTrue.Invoke(dontTrim ? value : value.Trim());
            }

            public static void IfNullOrEmptyOrWhiteSpace(this String value, Action actionIfTrue)
            {
                if (String.IsNullOrWhiteSpace(value))
                    actionIfTrue.Invoke();
            }

            public static void IfNull(this String value, Action actionIfTrue)
            {
                if(_internalHelpers.IsNull(value))
                    actionIfTrue.Invoke();
            }

            public static void IfEmpty(this String value, Action actionIfTrue)
            {
                if (_internalHelpers.IsEmpty(value))
                    actionIfTrue.Invoke();
            }

            public static void IfWhiteSpace(this String value, Action actionIfTrue)
            {
                if (_internalHelpers.IsWhiteSpace(value))
                    actionIfTrue.Invoke();
            }

            public static void IfNullOrEmpty(this String value, Action actionIfTrue)
            {
                if (_internalHelpers.IsNullOrEmpty(value))
                    actionIfTrue.Invoke();
            }

            public static void IfEmptyOrWhiteSpace(this String value, Action actionIfTrue)
            {
                if (_internalHelpers.IsEmptyOrWhiteSpace(value))
                    actionIfTrue.Invoke();
            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action<String> actionIfWhiteSpace, 
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (_internalHelpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (_internalHelpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke(value);
                else
                    actionIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());

            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action actionIfWhiteSpace, 
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (_internalHelpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (_internalHelpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke();
                else
                    actionIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());

            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action<String> actionIfWhiteSpace)
            {
                if (_internalHelpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (_internalHelpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (_internalHelpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke(value);
            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action actionIfWhiteSpace)
            {
                if (_internalHelpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (_internalHelpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (_internalHelpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke();
            }

            public static String IfNotNullOrEmptyOrWhiteSpace(this String value, Func<String, String> funcIfTrue, Func<String> funcIfFalse, Boolean dontTrim = false)
            {
                if (String.IsNullOrWhiteSpace(value))
                    return funcIfFalse.Invoke();

                return funcIfTrue.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNotNullOrEmptyOrWhiteSpace(this String value, Func<String> funcIfFalse, Boolean dontTrim = false)
            {
                if (String.IsNullOrWhiteSpace(value))
                    return funcIfFalse.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfNull(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    funcIfTrue.Invoke("NULL");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNull(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    funcIfTrue.Invoke("NULL");

                return dontTrim ? value : value.Trim();
            }

            public static String IfNull(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNull(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmpty(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmpty(value))
                    funcIfTrue.Invoke("EMPTY");

                return funcIfFalse(dontTrim ? value : value.Trim());
            }

            public static String IfEmpty(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmpty(value))
                    funcIfTrue.Invoke("EMPTY");

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmpty(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmpty(value))
                    funcIfTrue.Invoke();

                return funcIfFalse(dontTrim ? value : value.Trim());
            }

            public static String IfEmpty(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmpty(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfWhiteSpace(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke("WHITESPACE");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfWhiteSpace(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke("WHITESPACE");

                return dontTrim ? value : value.Trim();
            }

            public static String IfWhiteSpace(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfWhiteSpace(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfNullOrEmpty(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke("NULL-OR-EMPTY");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNullOrEmpty(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke("NULL-OR-EMPTY");

                return dontTrim ? value : value.Trim();
            }

            public static String IfNullOrEmpty(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNullOrEmpty(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke("EMPTY-OR-WHITESPACE");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke("EMPTY-OR-WHITESPACE");

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String If(this String value, Func<String, String> funcIfNull, Func<String, String> funcIfEmpty, Func<String, String> funcIfWhiteSpace, 
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    return funcIfNull.Invoke("NULL");
                else if (_internalHelpers.IsEmpty(value))
                    return funcIfEmpty.Invoke("EMPTY");
                else if (_internalHelpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke("WHITESPACE");
                else
                    return funcIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());
            }

            public static String If(this String value, Func<String, String> funcIfNull, Func<String, String> funcIfEmpty, Func<String, String> funcIfWhiteSpace, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    return funcIfNull.Invoke("NULL");
                else if (_internalHelpers.IsEmpty(value))
                    return funcIfEmpty.Invoke("EMPTY");
                else if (_internalHelpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke("WHITESPACE");
                else
                    return dontTrim ? value : value.Trim();
            }

            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String> funcIfWhiteSpace,
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    return funcIfNull.Invoke();
                else if (_internalHelpers.IsEmpty(value))
                    return funcIfEmpty.Invoke();
                else if (_internalHelpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke();
                else
                    return funcIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());
            }

            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String> funcIfWhiteSpace, Boolean dontTrim = false)
            {
                if (_internalHelpers.IsNull(value))
                    return funcIfNull.Invoke();
                else if (_internalHelpers.IsEmpty(value))
                    return funcIfEmpty.Invoke();
                else if (_internalHelpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke();
                else
                    return dontTrim ? value : value.Trim();
            }


        }
    }
}