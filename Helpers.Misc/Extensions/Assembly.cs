using System;
using System.Reflection;

namespace JasonPereira84.Helpers
{
    namespace Extensions
    {
        public static partial class Misc
        {
            public static Assembly LoadAssembly(this String assemblyName)
                => Assembly.Load(new AssemblyName(assemblyName));

            public static Boolean TryLoadLoadAssembly(this String assemblyName, out Assembly assembly)
            {
                assembly = LoadAssembly(assemblyName);
                return assembly != null;
            }

            public static T[] GetAssemblyAttributes<T>(this Assembly assembly)
                where T : Attribute
            {
                // Get attributes of this type.
                object[] attributes =
                    assembly.GetCustomAttributes(typeof(T), true);

                // If we didn't get anything, return null.
                if ((attributes == null) || (attributes.Length == 0))
                    return null;

                // Convert each of the attributes into
                // the desired type and return it.
                var retVal = new T[attributes.Length];
                for (int i = 0; i < attributes.Length; i++)
                    retVal[i] = attributes[i] as T;
                return retVal;
            }

            public static T GetAssemblyAttribute<T>(this Assembly assembly)
                where T : Attribute
                => GetAssemblyAttributes<T>(assembly)[0];

            public static String GetConfiguration(this Assembly assembly, String defaultValue)
            {
                AssemblyConfigurationAttribute _tryGet()
                {
                    var retVal = default(AssemblyConfigurationAttribute);
                    try { retVal = GetAssemblyAttribute<AssemblyConfigurationAttribute>(assembly); }
                    catch (Exception) { }
                    return retVal;
                }
                return SanitizeTo(_tryGet()?.Configuration, defaultValue);
            }

        }
    }
}