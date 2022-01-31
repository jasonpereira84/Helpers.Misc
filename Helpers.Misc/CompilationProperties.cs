using System;
using System.Collections;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    using Pair = KeyValuePair<String, String>;
    using Dictionary = Dictionary<String, String>;
    using Pairs = IEnumerable<KeyValuePair<String, String>>;

    public sealed class CompilationProperties : Pairs
    {
        internal const String Unknown = "Unknown";
        internal const String gitBranch = "gitBranch";
        internal const String gitCommit = "gitCommit";
        internal const String buildConfiguration = "buildConfiguration";

        private static String sanitize(String value)
            => String.IsNullOrWhiteSpace(value) ? Unknown : value.Trim();

        private readonly Dictionary<String, String> _dictionary;

        internal CompilationProperties(
            String gitBranch,
            String gitCommit,
            String buildConfiguration)
            => _dictionary = new Dictionary
            {
                { Constants.GitBranch, gitBranch },
                { Constants.GitCommit, gitCommit },
                { Constants.BuildConfiguration, buildConfiguration }
            };

        public CompilationProperties() : this(
            Unknown,
            Unknown,
            Unknown)
        { }

        public String GIT_BRANCH
        {
            get => _dictionary[Constants.GitBranch];
            set => _dictionary[Constants.GitBranch] = sanitize(value);
        }

        public String GIT_COMMIT
        {
            get => _dictionary[Constants.GitCommit];
            set => _dictionary[Constants.GitCommit] = sanitize(value);
        }

        public String BUILD_CONFIGURATION
        {
            get => _dictionary[Constants.BuildConfiguration];
            set => _dictionary[Constants.BuildConfiguration] = sanitize(value);
        }

        public IEnumerator<Pair> GetEnumerator()
        {
            return ((Pairs)_dictionary).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((Pairs)_dictionary).GetEnumerator();
        }
    }
}