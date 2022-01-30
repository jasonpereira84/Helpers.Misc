using System;
using System.Text;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean IsNull(this String value) 
                => value == null;
            public static Boolean IsNotNull(this String value) 
                => !IsNull(value);

            public static Boolean IsEmpty(this String value)
                => value.IsNull()
                    ? throw new ArgumentNullException(nameof(value))
                    : value.Length.Equals(0);
            public static Boolean IsNotEmpty(this String value) 
                => !IsEmpty(value);
            
            public static Boolean IsWhiteSpace(this String value)
                => value.IsNotEmpty() && value.Trim().Length.Equals(0);
            public static Boolean IsNotWhiteSpace(this String value) 
                => !IsWhiteSpace(value);
            
            public static Boolean IsNullOrEmpty(this String value) 
                => value.IsNull() || value.Length.Equals(0);
            public static Boolean IsNotNullOrEmpty(this String value) 
                => !IsNullOrEmpty(value);
            
            public static Boolean IsEmptyOrWhiteSpace(this String value) 
                => value.IsEmpty() || value.Trim().Length.Equals(0);
            public static Boolean IsNotEmptyOrWhiteSpace(this String value) 
                => !IsEmptyOrWhiteSpace(value);
            
            public static Boolean IsNullOrEmptyOrWhiteSpace(this String value) 
                => String.IsNullOrWhiteSpace(value);
            public static Boolean IsNotNullOrEmptyOrWhiteSpace(this String value) 
                => !IsNullOrEmptyOrWhiteSpace(value);
            
            public static (Boolean IsSane, String Value) EvaluateSanity(this String value, 
                String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
                => value.IsNull()
                    ? (false, valueIfNull)
                    : value.IsEmpty()
                        ? (false, valueIfEmpty)
                        : value.IsWhiteSpace()
                            ? (false, valueIfWhitespace)
                            : (true, dontTrim ? value : value.Trim());
            
            public static Boolean EvaluateSanity(this String value, out String saneValue, String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
            {
                var retVal = EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim);
                saneValue = retVal.Value;
                return retVal.IsSane;
            }

            public static Boolean EvaluateSanity(this String value, String variableName, out String saneValue, Boolean dontTrim = false)
                =>  variableName.IsNullOrEmptyOrWhiteSpace()
                    ? throw new ArgumentOutOfRangeException(nameof(variableName))
                    : EvaluateSanity(value, out saneValue, $"NULL-{variableName}", $"EMPTY-{variableName}", $"WHITESPACE-{variableName}", dontTrim);

            public static String Sanitize(this String value, String valueIfNull = "NULL", String valueIfEmpty = "EMPTY", String valueIfWhitespace = "WHITESPACE", Boolean dontTrim = false)
                => EvaluateSanity(value, valueIfNull, valueIfEmpty, valueIfWhitespace, dontTrim).Value;

            public static String Sanitize(this String value, String variableName, Boolean dontTrim = false)
                => variableName.IsNullOrEmptyOrWhiteSpace()
                    ? throw new ArgumentOutOfRangeException(nameof(variableName))
                    : EvaluateSanity(value, $"NULL-{variableName}", $"EMPTY-{variableName}", $"WHITESPACE-{variableName}", dontTrim).Value;

            public static String SanitizeTo(this String value, String valueIfNullOrEmptyOrWhiteSpace, Boolean dontTrim = false)
                => EvaluateSanity(value, valueIfNullOrEmptyOrWhiteSpace, valueIfNullOrEmptyOrWhiteSpace, valueIfNullOrEmptyOrWhiteSpace, dontTrim).Value;

            public static Boolean Matches(this String value, String otherValue) 
                => value.Equals(otherValue, StringComparison.OrdinalIgnoreCase);
            
            public static String SurroundWith(this String value, String @string) 
                => $"{@string}{value}{@string}";
            public static String SurroundWith(this String value, Char @char) 
                => $"{@char}{value}{@char}";
            
            public static String QuoteSINGLE(this String value) 
                => SurroundWith(value, "'");

            public static String QuoteDOUBLE(this String value) 
                => SurroundWith(value, '"');
            
            public static String Mask(this String value, Int32 startIndex, Int32 length, Char @char = '*')
            {
                if (value.IsNull())
                    throw new ArgumentNullException(nameof(value));

                if (value.IsEmpty())
                    throw new ArgumentOutOfRangeException(nameof(value));

                return value.Substring(0, startIndex) + new String(@char, (int)length) + value.Substring((int)(startIndex + length), (int)(value.Length - (startIndex + length)));
            }
            public static String Mask(this String value, Int32 length, Char @char = '*')
                => value.Mask(0, length, @char);

            public static void IfNullOrEmptyOrWhiteSpace(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNullOrEmptyOrWhiteSpace(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNullOrEmptyOrWhiteSpace(this String value, Action action)
                => value.IfNullOrEmptyOrWhiteSpace(s => action.Invoke());

            public static void IfNotNullOrEmptyOrWhiteSpace(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNotNullOrEmptyOrWhiteSpace(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNotNullOrEmptyOrWhiteSpace(this String value, Action action)
                => value.IfNotNullOrEmptyOrWhiteSpace(s => action.Invoke());

            public static void IfNull(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNull(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNull(this String value, Action action)
                => value.IfNull(s => action.Invoke());

            public static void IfNotNull(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNotNull(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNotNull(this String value, Action action)
                => value.IfNotNull(s => action.Invoke());

            public static void IfEmpty(this String value, Action<String> action)
                => PredicatedOn(s => s.IsEmpty(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfEmpty(this String value, Action action)
                => value.IfEmpty(s => action.Invoke());

            public static void IfNotEmpty(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNotEmpty(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNotEmpty(this String value, Action action)
                => value.IfNotEmpty(s => action.Invoke());

            public static void IfWhiteSpace(this String value, Action<String> action)
                => PredicatedOn(s => s.IsWhiteSpace(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfWhiteSpace(this String value, Action action)
                => value.IfWhiteSpace(s => action.Invoke());

            public static void IfNotWhiteSpace(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNotWhiteSpace(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNotWhiteSpace(this String value, Action action)
                => value.IfNotWhiteSpace(s => action.Invoke());

            public static void IfNullOrEmpty(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNullOrEmpty(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNullOrEmpty(this String value, Action action)
                => value.IfNullOrEmpty(s => action.Invoke());

            public static void IfNotNullOrEmpty(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNotNullOrEmpty(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNotNullOrEmpty(this String value, Action action)
                => value.IfNotNullOrEmpty(s => action.Invoke());

            public static void IfEmptyOrWhiteSpace(this String value, Action<String> action)
                => PredicatedOn(s => s.IsEmptyOrWhiteSpace(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfEmptyOrWhiteSpace(this String value, Action action)
                => value.IfEmptyOrWhiteSpace(s => action.Invoke());

            public static void IfNotEmptyOrWhiteSpace(this String value, Action<String> action)
                => PredicatedOn(s => s.IsNotEmptyOrWhiteSpace(), value, actionIfTrue: action, actionIfFalse: Helpers.Do.Nothing);
            public static void IfNotEmptyOrWhiteSpace(this String value, Action action)
                => value.IfNotEmptyOrWhiteSpace(s => action.Invoke());

            public static void If(this String value, Action<String> actionIfNull, Action<String> actionIfEmpty, Action<String> actionIfWhiteSpace,
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace)
            {
                if (value.IsNull())
                    actionIfNull.Invoke(value);
                else if (value.IsEmpty())
                    actionIfEmpty.Invoke(value);
                else if (value.IsWhiteSpace())
                    actionIfWhiteSpace.Invoke(value);
                else
                    actionIfNotNullOrEmptyOrWhiteSpace.Invoke(value);
            }
            public static void If(this String value, Action actionIfNull, Action<String> actionIfEmpty, Action<String> actionIfWhiteSpace,
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace)
                => value.If(s => actionIfNull.Invoke(), actionIfEmpty, actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action<String> actionIfWhiteSpace,
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace)
                => value.If(actionIfNull, s => actionIfEmpty.Invoke(), actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action actionIfWhiteSpace,
                Action<String> actionIfNotNullOrEmptyOrWhiteSpace)
                => value.If(actionIfNull, actionIfEmpty, s => actionIfWhiteSpace.Invoke(), actionIfNotNullOrEmptyOrWhiteSpace);
            public static void If(this String value, Action actionIfNull, Action actionIfEmpty, Action actionIfWhiteSpace,
                Action actionIfNotNullOrEmptyOrWhiteSpace)
                => value.If(actionIfNull, actionIfEmpty, actionIfWhiteSpace, s => actionIfNotNullOrEmptyOrWhiteSpace.Invoke());

            public static String IfNullOrEmptyOrWhiteSpace(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNullOrEmptyOrWhiteSpace(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNullOrEmptyOrWhiteSpace(this String value, Func<String> func)
                => value.IfNullOrEmptyOrWhiteSpace(s => func.Invoke());

            public static String IfNotNullOrEmptyOrWhiteSpace(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNotNullOrEmptyOrWhiteSpace(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNotNullOrEmptyOrWhiteSpace(this String value, Func<String> func)
                => value.IfNotNullOrEmptyOrWhiteSpace(s => func.Invoke());

            public static String IfNull(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNull(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNull(this String value, Func<String> func)
                => value.IfNull(s => func.Invoke());

            public static String IfNotNull(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNotNull(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNotNull(this String value, Func<String> func)
                => value.IfNotNull(s => func.Invoke());

            public static String IfEmpty(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsEmpty(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfEmpty(this String value, Func<String> func)
                => value.IfEmpty(s => func.Invoke());

            public static String IfNotEmpty(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNotEmpty(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNotEmpty(this String value, Func<String> func)
                => value.IfNotEmpty(s => func.Invoke());

            public static String IfWhiteSpace(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsWhiteSpace(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfWhiteSpace(this String value, Func<String> func)
                => value.IfWhiteSpace(s => func.Invoke());

            public static String IfNotWhiteSpace(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNotWhiteSpace(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNotWhiteSpace(this String value, Func<String> func)
                => value.IfNotWhiteSpace(s => func.Invoke());

            public static String IfNullOrEmpty(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNullOrEmpty(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNullOrEmpty(this String value, Func<String> func)
                => value.IfNullOrEmpty(s => func.Invoke());

            public static String IfNotNullOrEmpty(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNotNullOrEmpty(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNotNullOrEmpty(this String value, Func<String> func)
                => value.IfNotNullOrEmpty(s => func.Invoke());

            public static String IfEmptyOrWhiteSpace(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsEmptyOrWhiteSpace(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfEmptyOrWhiteSpace(this String value, Func<String> func)
                => value.IfEmptyOrWhiteSpace(s => func.Invoke());

            public static String IfNotEmptyOrWhiteSpace(this String value, Func<String, String> func)
                => PredicatedOn(s => s.IsNotEmptyOrWhiteSpace(), value, funcIfTrue: func, funcIfFalse: Helpers.Do.NothingWith);
            public static String IfNotEmptyOrWhiteSpace(this String value, Func<String> func)
                => value.IfNotEmptyOrWhiteSpace(s => func.Invoke());

            public static String If(this String value, Func<String, String> funcIfNull, Func<String, String> funcIfEmpty, Func<String, String> funcIfWhiteSpace,
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace)
            {
                if (value.IsNull())
                    return funcIfNull.Invoke(value);

                if (value.IsEmpty())
                    return funcIfEmpty.Invoke(value);

                if (value.IsWhiteSpace())
                    return funcIfWhiteSpace.Invoke(value);

                return funcIfNotNullOrEmptyOrWhiteSpace.Invoke(value);
            }
            public static String If(this String value, Func<String> funcIfNull, Func<String, String> funcIfEmpty, Func<String, String> funcIfWhiteSpace,
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace)
                => value.If(s => funcIfNull.Invoke(), funcIfEmpty, funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace);
            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String, String> funcIfWhiteSpace,
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace)
                => value.If(funcIfNull, s => funcIfEmpty.Invoke(), funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace);
            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String> funcIfWhiteSpace,
                Func<String, String> funcIfNotNullOrEmptyOrWhiteSpace)
                => value.If(funcIfNull, funcIfEmpty, s => funcIfWhiteSpace.Invoke(), funcIfNotNullOrEmptyOrWhiteSpace);
            public static String If(this String value, Func<String> funcIfNull, Func<String> funcIfEmpty, Func<String> funcIfWhiteSpace,
                Func<String> funcIfNotNullOrEmptyOrWhiteSpace)
                => value.If(funcIfNull, funcIfEmpty, funcIfWhiteSpace, s => funcIfNotNullOrEmptyOrWhiteSpace.Invoke());

        }
    }
}