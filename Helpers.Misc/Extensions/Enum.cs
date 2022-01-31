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
            internal static Type isEnum(Type type)
            {
                if (!type.IsEnum)
                    throw new ArgumentException("Must be an Enumeration type");

                return type;
            }

            public static T GetEnumValue<T>(this String value)
                where T : struct, IConvertible
                => isEnum(typeof(T))
                    .Do(type =>
                        Enum.TryParse(value, true, out T val)
                            ? val
                            : default(T));
            public static T GetEnumValue<T>(this UInt64 value)
                where T : struct, IConvertible
                => GetEnumValue<T>($"{value}");
            public static T GetEnumValue<T>(this Int64 value)
                where T : struct, IConvertible
                => GetEnumValue<T>($"{value}");
            public static T GetEnumValue<T>(this UInt32 value)
                where T : struct, IConvertible 
                => GetEnumValue<T>($"{value}");
            public static T GetEnumValue<T>(this Int32 value)
                where T : struct, IConvertible
                => GetEnumValue<T>($"{value}");

            public static Array GetAllEnum(this Type type)
                => Enum.GetValues(isEnum(type));
            public static Array GetAllEnum(this Enum @enum)
                => GetAllEnum(@enum.GetType());
            public static IEnumerable<T> GetAllEnum<T>()
                where T : struct, IConvertible
                => GetAllEnum(typeof(T)).Cast<T>();
            public static IEnumerable<T> GetAllEnum<T>(this Type type)
                where T : struct, IConvertible
                => GetAllEnum<T>();
            public static IEnumerable<T> GetAllEnum<T>(this T t)
                where T : struct, IConvertible
                => typeof(T).GetAllEnum<T>();

            public static String GetDisplayName(this Enum @enum, String defaultValue = default)
                => @enum.GetType()
                    .GetMember($"{@enum}")
                    .FirstOrDefault()?
                    .GetCustomAttribute<DisplayAttribute>(false)?.Name ?? defaultValue;
        }
    }
}
