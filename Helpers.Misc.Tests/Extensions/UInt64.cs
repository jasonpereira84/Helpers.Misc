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
        public class Test_UInt64
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = (UInt64)0;
                    var otherValue = (UInt64)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (UInt64)1;
                    var otherValue = (UInt64)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (UInt64)2;
                    var otherValue = (UInt64)1;
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = (UInt64)0;
                    var otherValue = (UInt64)1;
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (UInt64)1;
                    var otherValue = (UInt64)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (UInt64)2;
                    var otherValue = (UInt64)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = (UInt64)0;
                    var otherValue = (UInt64)1;
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = (UInt64)1;
                    var otherValue = (UInt64)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = (UInt64)2;
                    var otherValue = (UInt64)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = (UInt64)0;
                    var otherValue = (UInt64)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (UInt64)1;
                    var otherValue = (UInt64)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (UInt64)2;
                    var otherValue = (UInt64)1;
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = (UInt64)0;
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = (UInt64)1;
                    Assert.IsFalse(value.EqualsZero());
                }

            }

        }
    }
}
