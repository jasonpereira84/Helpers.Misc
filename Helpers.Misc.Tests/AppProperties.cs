using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    [TestClass]
    public class Test_AppProperties
    {
        [TestMethod]
        public void ctor()
        {
            var appProperties = new AppProperties(
                    "company",
                    "product",
                    "copyright",
                    "version",
                    "title",
                    "description",
                    "configuration");
            Assert.AreEqual(
                expected: "company",
                actual: appProperties.Company);
            Assert.AreEqual(
                expected: "product",
                actual: appProperties.Product);
            Assert.AreEqual(
                expected: "copyright",
                actual: appProperties.Copyright);
            Assert.AreEqual(
                expected: "version",
                actual: appProperties.Version);
            Assert.AreEqual(
                expected: "title",
                actual: appProperties.Title);
            Assert.AreEqual(
                expected: "description",
                actual: appProperties.Description);
            Assert.AreEqual(
                expected: "configuration",
                actual: appProperties.Configuration);
        }

    }
}
