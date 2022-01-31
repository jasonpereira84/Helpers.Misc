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
            public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type, Boolean dontIncludeParents = false)
            {
                if (type == null)
                    throw new ArgumentNullException(nameof(type));

                IEnumerable<PropertyInfo> getPublicProperties(Type t, Boolean p)
                    => t.GetProperties(
                        BindingFlags.Public |
                        BindingFlags.Instance |
                        (p ? BindingFlags.DeclaredOnly : BindingFlags.FlattenHierarchy));

                return type.If(t => !t.IsInterface,
                    funcIfTrue: t => getPublicProperties(t, dontIncludeParents),
                    funcIfFalse: t => new List<PropertyInfo>()
                        .Do(propertyInfos =>
                        {
                            var considered = new List<Type>()
                                .AddItem(type);
                            var queue = new Queue<Type>()
                                .EnqueueItem(type);
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
                                    getPublicProperties(subType, dontIncludeParents)
                                    .Except(propertyInfos));
                            }
                            return propertyInfos;
                        }));
            }

            public static IEnumerable<PropertyInfo> GetPublicProperties<T>(Boolean dontIncludeParents = false)
                => typeof(T).GetPublicProperties(dontIncludeParents);

        }
    }
}