using System;
using System.Text;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        using Internal;

        public static partial class Misc
        {
            public static Boolean IsNull(this String value) => Helpers.IsNull(value);
            public static Boolean IsNotNull(this String value) => !Helpers.IsNull(value);

            public static Boolean IsEmpty(this String nonNullString) => Helpers.IsEmpty(nonNullString);
            public static Boolean IsNotEmpty(this String nonNullString) => !Helpers.IsEmpty(nonNullString);

            public static Boolean IsWhiteSpace(this String nonNullString) => Helpers.IsWhiteSpace(nonNullString);
            public static Boolean IsNotWhiteSpace(this String nonNullString) => !Helpers.IsWhiteSpace(nonNullString);

            public static Boolean IsNullOrEmpty(this String value) => Helpers.IsNullOrEmpty(value);
            public static Boolean IsNotNullOrEmpty(this String value) => !Helpers.IsNullOrEmpty(value);

            public static Boolean IsEmptyOrWhiteSpace(this String nonNullString) => Helpers.IsEmptyOrWhiteSpace(nonNullString);
            public static Boolean IsNotEmptyOrWhiteSpace(this String nonNullString) => !Helpers.IsEmptyOrWhiteSpace(nonNullString);

            public static Boolean IsNullOrEmptyOrWhiteSpace(this String value) => Helpers.IsNullOrEmptyOrWhiteSpace(value);
            public static Boolean IsNotNullOrEmptyOrWhiteSpace(this String value) => !Helpers.IsNullOrEmptyOrWhiteSpace(value);

            public static (Boolean IsSane, String Value) EvaluateSanity(this String value, String valueIfNull, String valueIfEmpty, String valueIfWhitespace, Boolean dontTrim = false)
                => Helpers.EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);
            public static (Boolean IsSane, String Value) EvaluateSanity(this String value, Boolean dontTrim = false)
                => Helpers.EvaluateSanity(value, dontTrim);

            public static Boolean EvaluateSanity(this String value, out String saneValue, Boolean dontTrim = false)
            {
                var result = value.EvaluateSanity(dontTrim);
                saneValue = result.Value;
                return result.IsSane;
            }
            public static Boolean Sanitized(this String value, String name, out String saneValue, Boolean dontTrim = false)
                => Helpers.EvaluateSanity(value, name, out saneValue, dontTrim);
            public static String Sanitized(this String value, String name, Boolean dontTrim = false)
            {
                Helpers.EvaluateSanity(value, name, out String saneValue, dontTrim);
                return saneValue;
            }

            public static String SanitizeTo(this String value, String valueIfNull, String valueIfEmpty, String valueIfWhitespace, Boolean dontTrim = false) => Helpers.SanitizeTo(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);
            public static String SanitizeTo(this String value, String valueIfNullOrEmptyOrWhiteSpace, Boolean dontTrim = false) => Helpers.SanitizeTo(value, valueIfNullOrEmptyOrWhiteSpace, dontTrim);
            public static String Sanitize(this String value, Boolean dontTrim = false) => Helpers.Sanitize(value, dontTrim);
            public static String SanitizeTo(this String value, Func<String> func, Boolean dontTrim = false) => String.IsNullOrWhiteSpace(value) ? func.Invoke() : dontTrim ? value : value.Trim();


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
                if(Helpers.IsNull(value))
                    actionIfTrue.Invoke();
            }

            public static void IfEmpty(this String nonNullString, Action actionIfTrue)
            {
                if (Helpers.IsEmpty(nonNullString))
                    actionIfTrue.Invoke();
            }

            public static void IfWhiteSpace(this String nonNullString, Action actionIfTrue)
            {
                if (Helpers.IsWhiteSpace(nonNullString))
                    actionIfTrue.Invoke();
            }

            public static void IfNullOrEmpty(this String value, Action actionIfTrue)
            {
                if (Helpers.IsNullOrEmpty(value))
                    actionIfTrue.Invoke();
            }

            public static void IfEmptyOrWhiteSpace(this String nonNullString, Action actionIfTrue)
            {
                if (Helpers.IsEmptyOrWhiteSpace(nonNullString))
                    actionIfTrue.Invoke();
            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action<String> actionIfWhiteSpace, 
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (Helpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (Helpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke(value);
                else
                    actionIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());

            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action actionIfWhiteSpace, 
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (Helpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (Helpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke();
                else
                    actionIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());

            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action<String> actionIfWhiteSpace)
            {
                if (Helpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (Helpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (Helpers.IsWhiteSpace(value))
                    actionIfWhiteSpace.Invoke(value);
            }

            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action actionIfWhiteSpace)
            {
                if (Helpers.IsNull(value))
                    actionIfNull.Invoke();
                else if (Helpers.IsEmpty(value))
                    actionIfEmpty.Invoke();
                else if (Helpers.IsWhiteSpace(value))
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
                if (Helpers.IsNull(value))
                    funcIfTrue.Invoke("NULL");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNull(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    funcIfTrue.Invoke("NULL");

                return dontTrim ? value : value.Trim();
            }

            public static String IfNull(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNull(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmpty(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsEmpty(value))
                    funcIfTrue.Invoke("EMPTY");

                return funcIfFalse(dontTrim ? value : value.Trim());
            }

            public static String IfEmpty(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsEmpty(value))
                    funcIfTrue.Invoke("EMPTY");

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmpty(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsEmpty(value))
                    funcIfTrue.Invoke();

                return funcIfFalse(dontTrim ? value : value.Trim());
            }

            public static String IfEmpty(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsEmpty(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfWhiteSpace(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke("WHITESPACE");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfWhiteSpace(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke("WHITESPACE");

                return dontTrim ? value : value.Trim();
            }

            public static String IfWhiteSpace(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfWhiteSpace(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsWhiteSpace(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfNullOrEmpty(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke("NULL-OR-EMPTY");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNullOrEmpty(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke("NULL-OR-EMPTY");

                return dontTrim ? value : value.Trim();
            }

            public static String IfNullOrEmpty(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfNullOrEmpty(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsNullOrEmpty(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String, String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke("EMPTY-OR-WHITESPACE");

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String, String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke("EMPTY-OR-WHITESPACE");

                return dontTrim ? value : value.Trim();
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String> funcIfTrue, Func<String, String> funcIfFalse, Boolean dontTrim = false)
            {
                if (Helpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke();

                return funcIfFalse.Invoke(dontTrim ? value : value.Trim());
            }

            public static String IfEmptyOrWhiteSpace(this String value, Func<String> funcIfTrue, Boolean dontTrim = false)
            {
                if (Helpers.IsEmptyOrWhiteSpace(value))
                    funcIfTrue.Invoke();

                return dontTrim ? value : value.Trim();
            }

            public static String If(this String value, Func<String, String> funcIfNull, Func<String, String> funcIfEmpty, Func<String, String> funcIfWhiteSpace, 
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    return funcIfNull.Invoke("NULL");
                else if (Helpers.IsEmpty(value))
                    return funcIfEmpty.Invoke("EMPTY");
                else if (Helpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke("WHITESPACE");
                else
                    return funcIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());
            }

            public static String If(this String value, Func<String, String> funcIfNull, Func<String, String> funcIfEmpty, Func<String, String> funcIfWhiteSpace, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    return funcIfNull.Invoke("NULL");
                else if (Helpers.IsEmpty(value))
                    return funcIfEmpty.Invoke("EMPTY");
                else if (Helpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke("WHITESPACE");
                else
                    return dontTrim ? value : value.Trim();
            }

            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String> funcIfWhiteSpace,
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    return funcIfNull.Invoke();
                else if (Helpers.IsEmpty(value))
                    return funcIfEmpty.Invoke();
                else if (Helpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke();
                else
                    return funcIfNotNullOrEmptyOrWhiteSpace(dontTrim ? value : value.Trim());
            }

            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String> funcIfWhiteSpace, Boolean dontTrim = false)
            {
                if (Helpers.IsNull(value))
                    return funcIfNull.Invoke();
                else if (Helpers.IsEmpty(value))
                    return funcIfEmpty.Invoke();
                else if (Helpers.IsWhiteSpace(value))
                    return funcIfWhiteSpace.Invoke();
                else
                    return dontTrim ? value : value.Trim();
            }


        }
    }
}