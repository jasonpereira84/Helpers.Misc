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
        public class Test_Int64
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = (Int64)0;
                    var otherValue = (Int64)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Int64)1;
                    var otherValue = (Int64)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Int64)2;
                    var otherValue = (Int64)1;
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = (Int64)0;
                    var otherValue = (Int64)1;
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Int64)1;
                    var otherValue = (Int64)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Int64)2;
                    var otherValue = (Int64)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = (Int64)0;
                    var otherValue = (Int64)1;
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = (Int64)1;
                    var otherValue = (Int64)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = (Int64)2;
                    var otherValue = (Int64)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = (Int64)0;
                    var otherValue = (Int64)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Int64)1;
                    var otherValue = (Int64)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Int64)2;
                    var otherValue = (Int64)1;
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = (Int64)0;
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = (Int64)1;
                    Assert.IsFalse(value.EqualsZero());
                }

            }

            [TestMethod]
            public void IsNegative()
            {
                {
                    var value = (Int64)(-1);
                    Assert.IsTrue(value.IsNegative());
                }

                {
                    var value = (Int64)0;
                    Assert.IsFalse(value.IsNegative());
                }

                {
                    var value = (Int64)1;
                    Assert.IsFalse(value.IsNegative());
                }

            }

        }
    }
}
