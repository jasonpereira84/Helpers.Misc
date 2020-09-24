using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Type IsEnum(this Type type, Boolean dontEnsure = false)
            {
                if (dontEnsure)
                    return type?.IsEnum ?? false ? type : default(Type);

                Ensure.Argument.Is(type?.IsEnum ?? false, "T must be an Enumeration type");
                return type;
            }

            public static T GetEnumValue<T>(this String string_)
                where T : struct, IConvertible
                => IsEnum(typeof(T))
                    .Do(type =>
                        Enum.TryParse(string_, true, out T val)
                            ? val
                            : default(T));

            public static T GetEnumValue<T>(this UInt64 intValue)
                where T : struct, IConvertible
                => IsEnum(typeof(T))
                    .Do(type => (T)Enum.ToObject(type, intValue));

            public static T GetEnumValue<T>(this Int32 intValue)
                where T : struct, IConvertible
                => IsEnum(typeof(T))
                    .Do(type => (T)Enum.ToObject(type, intValue));

            public static Array GetAllEnum(this Type type)
                => Enum.GetValues(type);

            public static Array GetAllEnum(this Enum @enum)
                => GetAllEnum(IsEnum(@enum.GetType()));

            public static Array GetAllEnum<T>()
                where T : struct, IConvertible
                => GetAllEnum(IsEnum(typeof(T)));

            public static T[] GetAllEnum<T>(this Type type)
                where T : struct, IConvertible
                => (T[])type.GetAllEnum();

            public static T[] GetAllEnum<T>(this T t)
                where T : struct, IConvertible
                => IsEnum(typeof(T)).GetAllEnum<T>();

            public static String GetDisplayName(this Type type, String enumString)
                => IsEnum(type).GetMember(enumString)
                        .FirstOrDefault()?
                        .GetCustomAttribute<DisplayAttribute>(false)?
                        .Name
                    ?? enumString;

            public static String GetDisplayName(this Enum @enum)
                => GetDisplayName(IsEnum(@enum.GetType()), @enum.ToString());
        }
    }
}
