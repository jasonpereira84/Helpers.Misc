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
        public class Test_Byte
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = (Byte)0;
                    var otherValue = (Byte)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Byte)1;
                    var otherValue = (Byte)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Byte)2;
                    var otherValue = (Byte)1;
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = (Byte)0;
                    var otherValue = (Byte)1;
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Byte)1;
                    var otherValue = (Byte)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Byte)2;
                    var otherValue = (Byte)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = (Byte)0;
                    var otherValue = (Byte)1;
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = (Byte)1;
                    var otherValue = (Byte)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = (Byte)2;
                    var otherValue = (Byte)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = (Byte)0;
                    var otherValue = (Byte)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Byte)1;
                    var otherValue = (Byte)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Byte)2;
                    var otherValue = (Byte)1;
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = (Byte)0;
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = (Byte)1;
                    Assert.IsFalse(value.EqualsZero());
                }

            }

        }
    }
}
