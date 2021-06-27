using System;
using System.Net;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    using Pair = KeyValuePair<String, String>;
    using Dictionary = Dictionary<String, String>;
    using Pairs = IEnumerable<KeyValuePair<String, String>>;

    public sealed class CompilationProperties : Pairs
    {
        private readonly Dictionary<String, String> _dictionary;

        private CompilationProperties(Dictionary dictionary)
            => _dictionary = dictionary;

        public CompilationProperties()
            : this(
                  new Dictionary {
                      { Constants.GitBranch, "Unknown" },
                      { Constants.GitCommit, "Unknown" },
                      { Constants.BuildConfiguration, "Unknown" }
                  })
        { }

        public String GIT_BRANCH
        {
            get => _dictionary[Constants.GitBranch];
            set => _dictionary[Constants.GitBranch] = _internalHelpers.SanitizeTo(value, "Unknown");
        }

        public String GIT_COMMIT
        {
            get => _dictionary[Constants.GitCommit];
            set => _dictionary[Constants.GitCommit] = _internalHelpers.SanitizeTo(value, "Unknown");
        }

        public String BUILD_CONFIGURATION
        {
            get => _dictionary[Constants.BuildConfiguration];
            set => _dictionary[Constants.BuildConfiguration] = _internalHelpers.SanitizeTo(value, "Unknown");
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