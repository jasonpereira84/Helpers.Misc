using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Boolean IsNotEnum(this Type type)
            => !type.IsEnum;

            public static T NewIfNull<T>(this T t)
                where T : new()
                => t != null ? t : new T();

            public static String TypeName<T>(this T t)
                => typeof(T).Name;

            public static Boolean IsNotInterface(this Type type)
                => !type.IsInterface;

            public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type, Boolean includeParents)
            {
                IEnumerable<PropertyInfo> getPublicProperties(Type t, Boolean p)
                    => t.GetProperties(
                        BindingFlags.Public |
                        BindingFlags.Instance |
                        (p ? BindingFlags.FlattenHierarchy : BindingFlags.DeclaredOnly));

                return type.If(t => t.IsNotInterface(),
                    funcIfTrue: t => getPublicProperties(t, includeParents),
                    funcIfFalse: t => new List<PropertyInfo>()
                        .Do(propertyInfos =>
                        {
                            var considered = new List<Type>()
                                .Do(list => list.Add(type));
                            var queue = new Queue<Type>()
                                .Do(q => q.Enqueue(type));
                            while (queue.Count > 0)
                            {
                                var subType = queue.Dequeue();
                                foreach (var subInterface in subType
                                    .GetInterfaces()
                                    .Except(considered))
                                {
                                    considered.Add(subInterface);
                                    queue.Enqueue(subInterface);
                                };

                                propertyInfos.InsertRange(0,
                                    getPublicProperties(subType, includeParents)
                                    .Except(propertyInfos));
                            }
                        }));
            }

            public static IEnumerable<PropertyInfo> GetPublicProperties<T>(this T obj, Boolean includeParents)
                => obj.GetType().GetPublicProperties(includeParents);

            public static Boolean IsType(this PropertyInfo propertyInfo, Type type)
                => propertyInfo?.PropertyType?.Equals(type) ?? false;
        }
    }
}