using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_TimeSpan
        {
            [TestMethod]
            public void GreaterThan()
            {
                {
                    var value = new TimeSpan(0);
                    var otherValue = new TimeSpan(1);
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = new TimeSpan(1);
                    var otherValue = new TimeSpan(1);
                    Assert.IsFalse(value.GreaterThan(otherValue));
                }

                {
                    var value = new TimeSpan(2);
                    var otherValue = new TimeSpan(1);
                    Assert.IsTrue(value.GreaterThan(otherValue));
                }
            }

            [TestMethod]
            public void GreaterThanOrEqualTo()
            {
                {
                    var value = new TimeSpan(0);
                    var otherValue = new TimeSpan(1);
                    Assert.IsFalse(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = new TimeSpan(1);
                    var otherValue = new TimeSpan(1);
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }

                {
                    var value = new TimeSpan(2);
                    var otherValue = new TimeSpan(1);
                    Assert.IsTrue(value.GreaterThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void LessThan()
            {
                {
                    var value = new TimeSpan(0);
                    var otherValue = new TimeSpan(1);
                    Assert.IsTrue(value.LessThan(otherValue));
                }

                {
                    var value = new TimeSpan(1);
                    var otherValue = new TimeSpan(1);
                    Assert.IsFalse(value.LessThan(otherValue));
                }

                {
                    var value = new TimeSpan(2);
                    var otherValue = new TimeSpan(1);
                    Assert.IsFalse(value.LessThan(otherValue));
                }
            }

            [TestMethod]
            public void LessThanOrEqualTo()
            {
                {
                    var value = new TimeSpan(0);
                    var otherValue = new TimeSpan(1);
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = new TimeSpan(1);
                    var otherValue = new TimeSpan(1);
                    Assert.IsTrue(value.LessThanOrEqualTo(otherValue));
                }

                {
                    var value = new TimeSpan(2);
                    var otherValue = new TimeSpan(1);
                    Assert.IsFalse(value.LessThanOrEqualTo(otherValue));
                }
            }

            [TestMethod]
            public void EqualsZero()
            {
                {
                    var value = new TimeSpan(0);
                    Assert.IsTrue(value.EqualsZero());
                }

                {
                    var value = new TimeSpan(1);
                    Assert.IsFalse(value.EqualsZero());
                }

            }

            [TestMethod]
            public void IsNegative()
            {
                {
                    var value = new TimeSpan(-1);
                    Assert.IsTrue(value.IsNegative());
                }

                {
                    var value = new TimeSpan(0);
                    Assert.IsFalse(value.IsNegative());
                }

                {
                    var value = new TimeSpan(1);
                    Assert.IsFalse(value.IsNegative());
                }

            }

            [TestMethod]
            public void RemainingTimeSpan()
            {
                {
                    Assert.AreEqual(
                        expected: new TimeSpan(0, 0, 1),
                        actual: 1UL.RemainingTimeSpan(0));
                }

                {
                    Assert.ThrowsException<ArgumentOutOfRangeException>(
                        () => 0UL.RemainingTimeSpan(1));
                }

                {
                    Assert.AreEqual(
                        expected: new TimeSpan(0, 0, -1),
                        actual: 0UL.RemainingTimeSpan(1, true));
                }

            }

            [TestMethod]
            public void AsWords()
            {
                {
                    var timespan = new TimeSpan(0);
                    Assert.AreEqual("0 seconds", timespan.AsWords());
                }
            }

        }
    }
}
