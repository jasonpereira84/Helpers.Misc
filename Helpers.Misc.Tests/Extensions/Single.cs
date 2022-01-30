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
        public class Test_Single
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = (Single)0;
                    var otherValue = (Single)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Single)1;
                    var otherValue = (Single)1;
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = (Single)2;
                    var otherValue = (Single)1;
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = (Single)0;
                    var otherValue = (Single)1;
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Single)1;
                    var otherValue = (Single)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = (Single)2;
                    var otherValue = (Single)1;
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = (Single)0;
                    var otherValue = (Single)1;
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = (Single)1;
                    var otherValue = (Single)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = (Single)2;
                    var otherValue = (Single)1;
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = (Single)0;
                    var otherValue = (Single)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Single)1;
                    var otherValue = (Single)1;
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = (Single)2;
                    var otherValue = (Single)1;
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = (Single)0;
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = (Single)1;
                    Assert.IsFalse(value.EqualsZero());
                }

            }

            [TestMethod]
            public void IsNegative()
            {
                {
                    var value = (Single)(-1);
                    Assert.IsTrue(value.IsNegative());
                }

                {
                    var value = (Single)0;
                    Assert.IsFalse(value.IsNegative());
                }

                {
                    var value = (Single)1;
                    Assert.IsFalse(value.IsNegative());
                }

            }

        }
    }
}
