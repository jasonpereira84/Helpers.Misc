using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_IList
        {
            [TestMethod]
            public void AddItem()
            {
                var source = new List<SomeClass>();
                var value = new SomeClass();
                Assert.AreSame(
                    source.AddItem(() => value),
                    value);
            }

        }
    }
}
