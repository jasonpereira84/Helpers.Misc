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
                      { "GIT_BRANCH", "Unknown" },
                      { "GIT_COMMIT", "Unknown" },
                      { "BUILD_CONFIGURATION", "Unknown" }
                  })
        { }

        public String GIT_BRANCH
        {
            get => _dictionary["GIT_BRANCH"];
            set => _dictionary["GIT_BRANCH"] = _internalHelpers.SanitizeTo(value, "Unknown");
        }

        public String GIT_COMMIT
        {
            get => _dictionary["GIT_COMMIT"];
            set => _dictionary["GIT_COMMIT"] = _internalHelpers.SanitizeTo(value, "Unknown");
        }

        public String BUILD_CONFIGURATION
        {
            get => _dictionary["BUILD_CONFIGURATION"];
            set => _dictionary["BUILD_CONFIGURATION"] = _internalHelpers.SanitizeTo(value, "Unknown");
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