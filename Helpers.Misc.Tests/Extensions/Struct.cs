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
        public class Test_Struct
        {
            [TestMethod]
            public void NotHasValue()
            {
                {
                    var value = new Nullable<Int32>(1);
                    Assert.IsFalse(value.NotHasValue());
                }

                {
                    var value = default(Nullable<Int32>);
                    Assert.IsTrue(value.NotHasValue());
                }
            }

            [TestMethod]
            public void NotEquals()
            {
                {
                    var value = 1;
                    Assert.IsFalse(value.NotEquals(1));
                }

                {
                    var value = 1;
                    Assert.IsTrue(value.NotEquals(2));
                }
            }
        }
    }
}
