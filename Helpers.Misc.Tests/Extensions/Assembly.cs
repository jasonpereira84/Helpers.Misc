using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_Assembly
        {
            [TestMethod]
            public void LoadAssembly()
            {
                Assert.IsNotNull(
                    "JasonPereira84.Helpers.Misc".LoadAssembly());
            }

            [TestMethod]
            public void TryLoadLoadAssembly()
            {
                Assert.IsTrue(
                    "JasonPereira84.Helpers.Misc".TryLoadLoadAssembly(out Assembly dump));
            }

            [TestMethod]
            public void GetAttributes()
            {
                Assert.IsTrue(
                    Assembly.Load(new AssemblyName("JasonPereira84.Helpers.Misc"))
                    .GetAttributes<AssemblyProductAttribute>()
                    .Any());
            }

            [TestMethod]
            public void GetConfiguration()
            {
#if DEBUG
                Assert.AreEqual(
                    expected: "Debug",
                    actual: Assembly.Load(new AssemblyName("JasonPereira84.Helpers.Misc"))
                        .GetConfiguration("Unknown"));
#else
                Assert.AreEqual(
                    expected: "Release",
                    actual: Assembly.Load(new AssemblyName("JasonPereira84.Helpers.Misc"))
                        .GetConfiguration("Unknown"));
#endif
            }

            [TestMethod]
            public void GetAppProperties()
            {
                var appProperties = Assembly.Load(
                    new AssemblyName("JasonPereira84.Helpers.Misc"))
                    .GetAppProperties();

                Assert.AreEqual(
                    expected: "JasonPereira84",
                    actual: appProperties.Company);
                Assert.AreEqual(
                    expected: "Helpers.Misc",
                    actual: appProperties.Product);
                Assert.IsTrue(
                    appProperties.Copyright.Contains("Copyright") &&
                    appProperties.Copyright.Contains("2019"));
                Assert.IsTrue(appProperties.Version.Contains("."));
                Assert.AreEqual(
                    expected: "JasonPereira84's misc. helpers library",
                    actual: appProperties.Title);
                Assert.AreEqual(
                    expected: "Misc. helper methods, properties, objects etc.",
                    actual: appProperties.Description);
#if DEBUG
                Assert.AreEqual(
                    expected: "Debug",
                    actual: appProperties.Configuration);
#else
                Assert.AreEqual(
                    expected: "Release",
                    actual: appProperties.Configuration);
#endif
            }

        }
    }
}
