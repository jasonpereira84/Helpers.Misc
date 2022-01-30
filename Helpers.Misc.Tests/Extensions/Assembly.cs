using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace JasonPereira84.Helpers.Tests
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
            public void GetAssemblyAttributes()
            {
                Assert.IsTrue(
                    Assembly.Load(new AssemblyName("JasonPereira84.Helpers.Misc"))
                    .GetAssemblyAttributes<AssemblyProductAttribute>()
                    .Any());
            }

            [TestMethod]
            public void GetAssemblyAttribute()
            {
                Assert.AreEqual(
                    expected: "Helpers.Misc",
                    actual: Assembly.Load(new AssemblyName("JasonPereira84.Helpers.Misc"))
                        .GetAssemblyAttribute<AssemblyProductAttribute>()
                        .Product);
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

        }
    }
}
