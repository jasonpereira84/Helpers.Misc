using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_Enum
        {
            [TestMethod]
            public void isEnum()
            {
                Assert.IsNotNull(
                    Misc.isEnum(typeof(DayOfWeek)));

                Assert.Throws<ArgumentException>(
                    () => Misc.isEnum(typeof(Int32)));
            }

            [TestMethod]
            public void GetEnumValue()
            {
                Assert.AreEqual(
                    expected: DayOfWeek.Monday,
                    actual: $"{DayOfWeek.Monday}".GetEnumValue<DayOfWeek>());

                Assert.AreEqual(
                    expected: DayOfWeek.Monday,
                    actual: $"{(Int32)DayOfWeek.Monday}".GetEnumValue<DayOfWeek>());
            }

            [TestMethod]
            public void GetAllEnum()
            {
                var expected = Enum.GetValues(typeof(DayOfWeek))
                        .Cast<DayOfWeek>();
                var actual = typeof(DayOfWeek).GetAllEnum()
                        .Cast<DayOfWeek>();
                Assert.IsTrue(expected.SequenceEqual(actual));
            }

            [TestMethod]
            public void GetDisplayName()
            {
                Assert.AreEqual(
                    expected: default(String),
                    actual: DayOfWeek.Monday.GetDisplayName());

                Assert.AreEqual(
                    expected: $"{DayOfWeek.Monday}",
                    actual: DayOfWeek.Monday.GetDisplayName($"{DayOfWeek.Monday}"));

                Assert.AreEqual(
                    expected: displayName,
                    actual: testEnum.One.GetDisplayName());
            }
            private const String displayName = "Value is one";
            private enum testEnum
            {
                [Display(Name = displayName)]
                One = 1
            }

        }
    }
}
