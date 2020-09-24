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

        public static Person From<TPerson>(TPerson person)
            where TPerson : IPerson
            => new Person
            {
                Last = person.Last,
                First = person.First
            };
    }

    public sealed class SanePerson : IPerson
    {
        public String Last { get; private set; }

        public String First { get; private set; }

        private SanePerson() { }

        public static SanePerson From<TPerson>(TPerson person, Func<String, String> sanitizerLAST, Func<String, String> sanitizerFIRST)
            where TPerson : IPerson
            => new SanePerson
            {
                Last = sanitizerLAST.Invoke(person.Last),
                First = sanitizerFIRST.Invoke(person.First)
            };

        public static SanePerson From<TPerson>(TPerson person, Func<String, String> sanitizer)
            where TPerson : IPerson
            => From(person, sanitizer, sanitizer);

        public static SanePerson From<TPerson>(TPerson person)
            where TPerson : IPerson
        {
            Func<String, String> _sanitizer(String name)
                => new Func<String, String>(
                (value) =>
                {
                    _internalHelpers.EvaluateSanity(value, name, out String saneValue);
                    return saneValue;
                });

            return From(person, _sanitizer(nameof(IPerson.Last)), _sanitizer(nameof(IPerson.First)));
        }

        public String Fullname(String format)
            => format
                .Replace($"{{{nameof(Last)}}}", Last)
                .Replace($"{{{nameof(First)}}}", First);
    }
}