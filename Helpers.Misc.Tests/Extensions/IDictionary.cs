using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_IDictionary
        {
            [TestMethod]
            public void ValueOrDefault()
            {
                var dictionary = new Dictionary<Int32, Int32>
                {
                    new KeyValuePair<Int32,Int32>(1, 1)
                };

                Assert.AreEqual(
                    expected: 1,
                    actual: dictionary.ValueOrDefault(1));

                Assert.AreEqual(
                    expected: default(Int32),
                    actual: dictionary.ValueOrDefault(2));

                Assert.AreEqual(
                    expected: 1,
                    actual: dictionary.ValueOrDefault(2, 1));
            }

        }
    }
}
