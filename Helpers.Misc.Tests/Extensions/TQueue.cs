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
        public class Test_TQueue
        {
            [TestMethod]
            public void AddItem()
            {
                var source = new Queue<Object>();
                var value = new Object();
                Assert.IsTrue(source.EnqueueItem(value).Contains(value));
            }

        }
    }
}
