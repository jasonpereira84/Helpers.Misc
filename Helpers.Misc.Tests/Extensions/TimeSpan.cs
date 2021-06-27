using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.UnitTests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_TimeSpan
        {
            [TestMethod]
            public void AsWords()
            {
                {
                    var timespan = TimeSpan.Zero;
                    Assert.AreEqual("0 seconds", timespan.AsWords());
                }
            }

        }
    }
}
