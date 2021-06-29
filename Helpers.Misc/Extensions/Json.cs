using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Stack = Stack<String>;
    using IDictionary = IDictionary<String, String>;
    using SortedDictionary = SortedDictionary<String, String>;

    namespace Extensions
    {
        public static partial class Misc
        {
            public static T Deserialize<T>(this String value, T defaultValue = default(T))
            where T : class
            => JsonConvert.DeserializeObject<T>(value) ?? defaultValue;

            public static IEnumerable<TResult> Deserialize<TSource, TResult>(this String value, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector, IEnumerable<TSource> defaultValue = default(IEnumerable<TSource>))
                => Deserialize(value, defaultValue).Where(predicate).Select(selector);

            public static List<TResult> Deserialize<TSource, TResult>(this String value, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector, List<TSource> defaultValue = default(List<TSource>))
                => Deserialize(value, predicate, selector, defaultValue as IEnumerable<TSource>).ToList();

            public static String Serialize<T>(this T value, T defaultValue = default(T))
                where T : class
                => JsonConvert.SerializeObject(value ?? defaultValue);

            public static String Serialize<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate, Func<TSource, TResult> selector, IEnumerable<TResult> defaultValue = default(IEnumerable<TResult>))
                => Serialize(source?.Where(predicate)?.Select(selector), defaultValue);

            public static IDictionary Parse(this JsonTextReader jsonTextReader, String delimiter = ":")
            {
                var dictionary = new SortedDictionary(StringComparer.OrdinalIgnoreCase);
                var currentPath = default(String);
                var stack = new Stack();

                void _enterContext(String context)
                {
                    stack.Push(context);
                    currentPath = String.Join(delimiter, stack.Reverse());
                }

                void _exitContext()
                {
                    stack.Pop();
                    currentPath = String.Join(delimiter, stack.Reverse());
                }

                void _visitToken(JToken jToken)
                {
                    switch (jToken.Type)
                    {
                        case JTokenType.Object:
                            _visitJObject(jToken.Value<JObject>());
                            break;

                        case JTokenType.Array:
                            _visitArray(jToken.Value<JArray>());
                            break;

                        case JTokenType.Integer:
                        case JTokenType.Float:
                        case JTokenType.String:
                        case JTokenType.Boolean:
                        case JTokenType.Bytes:
                        case JTokenType.Raw:
                        case JTokenType.Null:
                            _visitPrimitive(jToken.Value<JValue>());
                            break;

                        default:
                            throw new FormatException($"Unsupported JSON token '{jsonTextReader.TokenType}' was found. Path '{jsonTextReader.Path}', line {jsonTextReader.LineNumber} position {jsonTextReader.LinePosition}.");
                    }
                }

                void _visitPrimitive(JValue jValue)
                {
                    if (dictionary.ContainsKey(currentPath))
                        throw new FormatException($"A duplicate key '{currentPath}' was found.");

                    dictionary[currentPath] = jValue.ToString(CultureInfo.InvariantCulture);
                }

                void _visitProperty(JProperty jProperty)
                {
                    _visitToken(jProperty.Value);
                }

                void _visitArray(JArray jArray)
                {
                    for (int index = 0; index < jArray.Count; index++)
                    {
                        _enterContext(index.ToString());
                        _visitToken(jArray[index]);
                        _exitContext();
                    }
                }

                void _visitJObject(JObject jObject)
                {
                    foreach (var property in jObject.Properties())
                    {
                        _enterContext(property.Name);
                        _visitProperty(property);
                        _exitContext();
                    }
                }

                _visitJObject(JObject.Load(jsonTextReader));
                return dictionary;
            }
            public static IDictionary Parse(this StreamReader streamReader, String delimiter = ":", DateParseHandling dateParseHandling = DateParseHandling.None)
            {
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    jsonTextReader.DateParseHandling = dateParseHandling;

                    return Parse(jsonTextReader, delimiter);
                }
            }
            public static IDictionary Parse(this Stream inputStream, String delimiter = ":", DateParseHandling dateParseHandling = DateParseHandling.None)
            {
                using (var streamReader = new StreamReader(inputStream))
                {
                    return Parse(streamReader, delimiter, dateParseHandling);
                }
            }
            public static IDictionary Parse(this String path, String delimiter = ":", DateParseHandling dateParseHandling = DateParseHandling.None)
            {
                using (var streamReader = new StreamReader(path))
                {
                    return Parse(streamReader, delimiter, dateParseHandling);
                }
            }
        }
    }
}