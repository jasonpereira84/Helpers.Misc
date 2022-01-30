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
        public class Test_Double
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = (Double)0;
                    var otherValue = (Double)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Double)1;
                    var otherValue = (Double)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Double)2;
                    var otherValue = (Double)1;
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = (Double)0;
                    var otherValue = (Double)1;
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Double)1;
                    var otherValue = (Double)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Double)2;
                    var otherValue = (Double)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = (Double)0;
                    var otherValue = (Double)1;
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = (Double)1;
                    var otherValue = (Double)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = (Double)2;
                    var otherValue = (Double)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = (Double)0;
                    var otherValue = (Double)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Double)1;
                    var otherValue = (Double)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Double)2;
                    var otherValue = (Double)1;
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = (Double)0;
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = (Double)1;
                    Assert.IsFalse(value.EqualsZero());
                }

            }

            [TestMethod]
            public void IsNegative()
            {
                {
                    var value = (Double)(-1);
                    Assert.IsTrue(value.IsNegative());
                }

                {
                    var value = (Double)0;
                    Assert.IsFalse(value.IsNegative());
                }

                {
                    var value = (Double)1;
                    Assert.IsFalse(value.IsNegative());
                }

            }

        }
    }
}
