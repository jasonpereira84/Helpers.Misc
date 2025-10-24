using System;
using System.Linq;
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

            public static T[] GetAttributes<T>(this Assembly assembly)
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

            public static Boolean TryGetAttribute<T>(this Assembly assembly, out T attribute)
                where T : Attribute
            {
                try 
                {
                    attribute = GetAttributes<T>(assembly)[0];
                    return true;
                }
                catch 
                {
                    attribute = default(T);
                    return false;
                }
            }

            public static AppProperties GetAppProperties(this Assembly assembly)
            {
                String _get<T>(Func<T, String> getter)
                    where T : Attribute
                    => !TryGetAttribute(assembly, out T attribute) ? "?"
                        : SanitizeTo(getter.Invoke(attribute), "?");

                return new AppProperties(
                    _get<AssemblyCompanyAttribute>(attribute => attribute?.Company),
                    _get<AssemblyProductAttribute>(attribute => attribute?.Product),
                    _get<AssemblyCopyrightAttribute>(attribute => attribute?.Copyright),
                    _get<AssemblyInformationalVersionAttribute>(attribute => attribute?.InformationalVersion),
                    _get<AssemblyTitleAttribute>(attribute => attribute?.Title),
                    _get<AssemblyDescriptionAttribute>(attribute => attribute?.Description),
                    _get<AssemblyConfigurationAttribute>(attribute => attribute?.Configuration));
            }

            public static CompilationProperties GetCompilationProperties(this Assembly assembly)
            {
                var customAttributes = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
                    .ToDictionary(
                        keySelector: x => x.Key,
                        elementSelector: x => x.Value);

                return new CompilationProperties
                {
                    GIT_BRANCH = customAttributes.ValueOrDefault("GitBranch", "no-GitBranch-attribute-found"),
                    GIT_COMMIT = customAttributes.ValueOrDefault("GitCommit", "no-GitCommit-attribute-found"),
                    BUILD_CONFIGURATION = customAttributes.ValueOrDefault("BuildConfiguration", "no-BuildConfiguration-attribute-found")
                };
            }

        }
    }
}