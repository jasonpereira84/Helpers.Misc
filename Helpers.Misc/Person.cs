using System;

namespace JasonPereira84.Helpers
{
    public interface IPerson
    {
        String LastName { get; }

        String FirstName { get; }
    }

    public class Person : IPerson
    {
        public String LastName { get; set; } = default(String);

        public String FirstName { get; set; } = default(String);
    }

    public sealed class SanePerson : IPerson
    {
        public String LastName { get; private set; }

        public String FirstName { get; private set; }

        private SanePerson() { }

        private static String sanitizer(String name, String value)
            => value == null
                ? $"NULL-{name}"
                : value.Length.Equals(0)
                    ? $"EMPTY-{name}"
                    : (value = value.Trim()).Length.Equals(0)
                        ? $"WHITESPACE-{name}"
                        : value;

        public static SanePerson From(IPerson person, Func<String, String> sanitizerLAST, Func<String, String> sanitizerFIRST)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            if (sanitizerLAST == null)
                throw new ArgumentNullException(nameof(sanitizerLAST));

            if (sanitizerFIRST == null)
                throw new ArgumentNullException(nameof(sanitizerFIRST));

            return new SanePerson
            {
                LastName = sanitizer(nameof(IPerson.LastName), sanitizerLAST.Invoke(person.LastName)),
                FirstName = sanitizer(nameof(IPerson.FirstName), sanitizerFIRST.Invoke(person.FirstName))
            };
        }

        public static SanePerson From(IPerson person, Func<String, String> sanitizer)
            => From(person, sanitizer, sanitizer);

        public static SanePerson From(IPerson person)
            => From(person,
                sanitizerLAST: v => sanitizer(nameof(IPerson.LastName), v),
                sanitizerFIRST: v => sanitizer(nameof(IPerson.FirstName), v));
    }
}