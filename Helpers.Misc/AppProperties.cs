using System;
using System.Collections;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    using Pair = KeyValuePair<String, String>;
    using Dictionary = Dictionary<String, String>;
    using Pairs = IEnumerable<KeyValuePair<String, String>>;

    public sealed class AppProperties : Pairs
    {
        private readonly Dictionary<String, String> _dictionary;

        internal AppProperties(
            String company,
            String product,
            String copyright,
            String version,
            String title,
            String description,
            String configuration)
            => _dictionary = new Dictionary
            {
                { "Company", company },
                { "Product", product },
                { "Copyright", copyright },
                { "Version", version },
                { "Title", title },
                { "Description", description },
                { "Configuration", configuration }
            };

        public String Company
        {
            get => _dictionary["Company"];
            internal set => _dictionary["Company"] = value; 
        }

        public String Product
        {
            get => _dictionary["Product"];
            internal set => _dictionary["Product"] = value;
        }

        public String Copyright
        {
            get => _dictionary["Copyright"];
            internal set => _dictionary["Copyright"] = value;
        }

        public String Version
        {
            get => _dictionary["Version"];
            internal set => _dictionary["Version"] = value;
        }

        public String Title
        {
            get => _dictionary["Title"];
            internal set => _dictionary["Title"] = value;
        }

        public String Description
        {
            get => _dictionary["Description"];
            internal set => _dictionary["Description"] = value;
        }

        public String Configuration
        {
            get => _dictionary["Configuration"];
            internal set => _dictionary["Configuration"] = value;
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