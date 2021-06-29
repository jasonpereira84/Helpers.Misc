using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.UnitTests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_DateTime
        {
            [TestMethod]
            public void FirstWeekdayOfMonth()
            {
                Assert.AreEqual(1, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Tuesday).Day);
                Assert.AreEqual(2, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Wednesday).Day);
                Assert.AreEqual(3, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Thursday).Day);
                Assert.AreEqual(4, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Friday).Day);
                Assert.AreEqual(5, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Saturday).Day);
                Assert.AreEqual(6, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Sunday).Day);
                Assert.AreEqual(7, MonthsOfYear.June.FirstWeekdayOfMonth(2021, DayOfWeek.Monday).Day);
            }

            [TestMethod]
            public void LastWeekdayOfMonth()
            {
                Assert.AreEqual(24, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Thursday).Day);
                Assert.AreEqual(25, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Friday).Day);
                Assert.AreEqual(26, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Saturday).Day);
                Assert.AreEqual(27, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Sunday).Day);
                Assert.AreEqual(28, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Monday).Day);
                Assert.AreEqual(29, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Tuesday).Day);
                Assert.AreEqual(30, MonthsOfYear.June.LastWeekdayOfMonth(2021, DayOfWeek.Wednesday).Day);
            }

            [TestMethod]
            public void DayOfMonth()
            {
                {
                    Assert.AreEqual(30, MonthsOfYear.June.DayOfMonth(2021, WeekOfMonth.Fifth, DayOfWeek.Wednesday).Day);
                }

                {
                    try
                    {
                        MonthsOfYear.June.DayOfMonth(2021, WeekOfMonth.Fifth, DayOfWeek.Thursday);
                    }
                    catch(DateNotFoundException)
                    {
                        Assert.IsTrue(true);
                    }
                    Assert.AreEqual(24, MonthsOfYear.June.DayOfMonth(2021, WeekOfMonth.Fifth, DayOfWeek.Thursday, dontThrowException: true).Day);
                }
            }

            [TestMethod]
            public void DayOfYear()
            {
                {
                    Assert.AreEqual(31, 2021.DayOfYear(WeekOfYear.FiftySecond, DayOfWeek.Friday).Day);
                }

                {
                    try
                    {
                        2021.DayOfYear(WeekOfYear.FiftySecond, DayOfWeek.Saturday);
                    }
                    catch (DateNotFoundException)
                    {
                        Assert.IsTrue(true);
                    }
                    Assert.AreEqual(25, 2021.DayOfYear(WeekOfYear.FiftySecond, DayOfWeek.Saturday, dontThrowException: true).Day);
                }
            }

        }
    }
}
