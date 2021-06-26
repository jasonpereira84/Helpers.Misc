using System;

namespace JasonPereira84.Helpers
{
    public interface IPerson
    {
        String First { get; }

        String Last { get; }
    }

    public class Person : IPerson
    {
        public String First { get; set; } = default(String);

        public String Last { get; set; } = default(String);
    }

    public sealed class SanePerson : IPerson
    {
        public String Last { get; private set; }

        public String First { get; private set; }

        private SanePerson(String last, String first) 
        {
            Last = last;
            First = first;
        }

        public static SanePerson From(IPerson person, Func<String, String> sanitizerLAST, Func<String, String> sanitizerFIRST)
            => new SanePerson(sanitizerLAST.Invoke(person.Last), sanitizerFIRST.Invoke(person.First));

        public static SanePerson From(IPerson person, Func<String, String> sanitizer)
            => From(person, sanitizer, sanitizer);

        public static SanePerson From(IPerson person)
        {
            String _sanitize(String name, String value)
            {
                _internalHelpers.EvaluateSanity(value, name, out String saneValue);
                return saneValue;
            }

            return From(person,
                sanitizerLAST: v => _sanitize(nameof(IPerson.Last), v), 
                sanitizerFIRST: v => _sanitize(nameof(IPerson.First), v));
        }
    }
}