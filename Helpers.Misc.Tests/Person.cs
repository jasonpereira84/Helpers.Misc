using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Tests
{
    [TestClass]
    public class Test_Person
    {
        [TestMethod]
        public void From()
        {
            {
                Assert.ThrowsException<ArgumentNullException>(
                    () => SanePerson.From(default, value => value, value => value));
            }

            {
                Assert.ThrowsException<ArgumentNullException>(
                    () => SanePerson.From(new Person(), default, value => value));
            }

            {
                Assert.ThrowsException<ArgumentNullException>(
                    () => SanePerson.From(new Person(), value => value, default));
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person(),
                    sanitizerLAST: value => String.IsNullOrWhiteSpace(value) ? "Last" : value.Trim(),
                    sanitizerFIRST: value => String.IsNullOrWhiteSpace(value) ? "First" : value.Trim());
                Assert.AreEqual(
                    expected: "Last",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "First",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { LastName = "Fonda"},
                    sanitizerLAST: value => String.IsNullOrWhiteSpace(value) ? "Last" : value.Trim(),
                    sanitizerFIRST: value => String.IsNullOrWhiteSpace(value) ? "First" : value.Trim());
                Assert.AreEqual(
                    expected: "Fonda",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "First",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { FirstName = "Henry" },
                    sanitizerLAST: value => String.IsNullOrWhiteSpace(value) ? "Last" : value.Trim(),
                    sanitizerFIRST: value => String.IsNullOrWhiteSpace(value) ? "First" : value.Trim());
                Assert.AreEqual(
                    expected: "Last",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "Henry",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { LastName = "Fonda" },
                    sanitizerLAST: value => value,
                    sanitizerFIRST: value => value);
                Assert.AreEqual(
                    expected: "Fonda",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "NULL-FirstName",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { LastName = "Fonda", FirstName = "" },
                    sanitizerLAST: value => value,
                    sanitizerFIRST: value => value);
                Assert.AreEqual(
                    expected: "Fonda",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "EMPTY-FirstName",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { LastName = "Fonda", FirstName = " " },
                    sanitizerLAST: value => value,
                    sanitizerFIRST: value => value);
                Assert.AreEqual(
                    expected: "Fonda",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "WHITESPACE-FirstName",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { FirstName = "Henry" },
                    sanitizerLAST: value => value,
                    sanitizerFIRST: value => value);
                Assert.AreEqual(
                    expected: "NULL-LastName",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "Henry",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { LastName = "", FirstName = "Henry" },
                    sanitizerLAST: value => value,
                    sanitizerFIRST: value => value);
                Assert.AreEqual(
                    expected: "EMPTY-LastName",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "Henry",
                    actual: sanePerson.FirstName);
            }

            {
                var sanePerson = SanePerson.From(
                    person: new Person { LastName = " ", FirstName = "Henry" },
                    sanitizerLAST: value => value,
                    sanitizerFIRST: value => value);
                Assert.AreEqual(
                    expected: "WHITESPACE-LastName",
                    actual: sanePerson.LastName);
                Assert.AreEqual(
                    expected: "Henry",
                    actual: sanePerson.FirstName);
            }

        }
    }
}
