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
        public class Test_SByte
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = (SByte)0;
                    var otherValue = (SByte)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (SByte)1;
                    var otherValue = (SByte)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (SByte)2;
                    var otherValue = (SByte)1;
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = (SByte)0;
                    var otherValue = (SByte)1;
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (SByte)1;
                    var otherValue = (SByte)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (SByte)2;
                    var otherValue = (SByte)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = (SByte)0;
                    var otherValue = (SByte)1;
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = (SByte)1;
                    var otherValue = (SByte)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = (SByte)2;
                    var otherValue = (SByte)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = (SByte)0;
                    var otherValue = (SByte)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (SByte)1;
                    var otherValue = (SByte)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (SByte)2;
                    var otherValue = (SByte)1;
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = (SByte)0;
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = (SByte)1;
                    Assert.IsFalse(value.EqualsZero());
                }

            }

            [TestMethod]
            public void IsNegative()
            {
                {
                    var value = (SByte)(-1);
                    Assert.IsTrue(value.IsNegative());
                }

                {
                    var value = (SByte)0;
                    Assert.IsFalse(value.IsNegative());
                }

                {
                    var value = (SByte)1;
                    Assert.IsFalse(value.IsNegative());
                }

            }

        }
    }
}
