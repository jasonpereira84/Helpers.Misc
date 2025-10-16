using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_DateTime
        {
            [TestMethod]
            public void AsDateTimeUTC()
            {
                Assert.AreEqual(
                    expected: new DateTime(2019, 1, 1, 0, 0, 0),
                    actual: 63681897600UL.AsDateTimeUTC());
            }

            [TestMethod]
            public void AsUnixTime()
            {
                {
                    Assert.AreEqual(
                        expected: 1546300800UL,
                        actual: (new DateTime(2019, 1, 1, 0, 0, 0)).AsUnixTime());
                }

                {
                    Assert.AreEqual(
                        expected: 1546300800UL,
                        actual: (new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero)).AsUnixTime());
                }
            }

            [TestMethod]
            public void FirstDayOfMonth()
            {
                {
                    {
                        var year = (UInt16)0;
                        Assert.Throws<ArgumentOutOfRangeException>(
                            () => year.FirstDayOfMonth(MonthsOfYear.January, DateTimeKind.Utc));
                    }

                    {
                        var year = (UInt16)2019;
                        Assert.AreEqual(
                            expected: new DateTime(2019, 1, 1),
                            actual: year.FirstDayOfMonth(MonthsOfYear.January, DateTimeKind.Utc));
                    }
                }

                {
                    {
                        Assert.Throws<ArgumentOutOfRangeException>(
                            () => MonthsOfYear.January.FirstDayOfMonth(0));
                    }

                    {
                        Assert.AreEqual(
                            expected: new DateTime(2019, 1, 1),
                            actual: MonthsOfYear.January.FirstDayOfMonth(2019));
                    }
                }

            }

            [TestMethod]
            public void FirstDayOfWeekOfMonth()
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => MonthsOfYear.January.FirstDayOfWeekOfMonth(0, DayOfWeek.Sunday));

                Assert.AreEqual(
                    expected: 6, 
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Sunday).Day);
                Assert.AreEqual(
                    expected: 7,
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Monday).Day);
                Assert.AreEqual(
                    expected: 1,
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Tuesday).Day);
                Assert.AreEqual(
                    expected: 2,
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Wednesday).Day);
                Assert.AreEqual(
                    expected: 3,
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Thursday).Day);
                Assert.AreEqual(
                    expected: 4,
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Friday).Day);
                Assert.AreEqual(
                    expected: 5,
                    actual: MonthsOfYear.January.FirstDayOfWeekOfMonth(2019, DayOfWeek.Saturday).Day);
            }

            [TestMethod]
            public void LastDayOfWeekOfMonth()
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => MonthsOfYear.January.LastDayOfWeekOfMonth(0, DayOfWeek.Sunday));

                Assert.AreEqual(
                    expected: 27,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Sunday).Day);
                Assert.AreEqual(
                    expected: 28,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Monday).Day);
                Assert.AreEqual(
                    expected: 29,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Tuesday).Day);
                Assert.AreEqual(
                    expected: 30,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Wednesday).Day);
                Assert.AreEqual(
                    expected: 31,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Thursday).Day);
                Assert.AreEqual(
                    expected: 25,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Friday).Day);
                Assert.AreEqual(
                    expected: 26,
                    actual: MonthsOfYear.January.LastDayOfWeekOfMonth(2019, DayOfWeek.Saturday).Day);
            }

            [TestMethod]
            public void DayOfMonth()
            {
                Assert.Throws<ArgumentOutOfRangeException>(
                    () => MonthsOfYear.January.DayOfMonth(0, WeekOfMonth.First, DayOfWeek.Sunday));

                Assert.AreEqual(
                    expected: 6, 
                    actual: MonthsOfYear.January.DayOfMonth(2019, WeekOfMonth.First, DayOfWeek.Sunday).Day);

                Assert.AreEqual(
                    expected: 28,
                    actual: MonthsOfYear.January.DayOfMonth(2019, WeekOfMonth.Fourth, DayOfWeek.Monday).Day);

                Assert.Throws<DateNotFoundException>(
                    () => MonthsOfYear.January.DayOfMonth(2019, WeekOfMonth.Fifth, DayOfWeek.Monday));
                Assert.AreEqual(
                    expected: 28,
                    actual: MonthsOfYear.January.DayOfMonth(2019, WeekOfMonth.Fifth, DayOfWeek.Monday, dontThrowException: true).Day);

                Assert.AreEqual(
                    expected: 29,
                    actual: MonthsOfYear.January.DayOfMonth(2019, WeekOfMonth.Fifth, DayOfWeek.Tuesday).Day);
            }

            [TestMethod]
            public void DayOfYear()
            {
                {
                    var year = (UInt16)0;
                    Assert.Throws<ArgumentOutOfRangeException>(
                        () => year.DayOfYear(WeekOfYear.First, DayOfWeek.Sunday));
                }

                {
                    var year = (UInt16)2019;

                    Assert.AreEqual(
                        expected: 11,
                        actual: year.DayOfYear(WeekOfYear.Second, DayOfWeek.Friday).Day);

                    Assert.AreEqual(
                        expected: 31,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Tuesday).Day);

                    Assert.Throws<DateNotFoundException>(
                        () => year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Wednesday));
                    Assert.AreEqual(
                        expected: 25,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Wednesday, true).Day);
                }

                {
                    var year = (UInt16)2018;

                    Assert.AreEqual(
                        expected: 12,
                        actual: year.DayOfYear(WeekOfYear.Second, DayOfWeek.Friday).Day);

                    Assert.AreEqual(
                        expected: 31,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Monday).Day);

                    Assert.Throws<DateNotFoundException>(
                        () => year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Tuesday));
                    Assert.AreEqual(
                        expected: 25,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Tuesday, true).Day);
                }

                {
                    var year = (UInt16)2017;

                    Assert.AreEqual(
                        expected: 13,
                        actual: year.DayOfYear(WeekOfYear.Second, DayOfWeek.Friday).Day);

                    Assert.AreEqual(
                        expected: 31,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Sunday).Day);

                    Assert.Throws<DateNotFoundException>(
                        () => year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Monday));
                    Assert.AreEqual(
                        expected: 25,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Monday, true).Day);
                }

                {
                    var year = (UInt16)2016;

                    Assert.AreEqual(
                        expected: 8,
                        actual: year.DayOfYear(WeekOfYear.Second, DayOfWeek.Friday).Day);

                    Assert.AreEqual(
                        expected: 31,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Saturday).Day);

                    Assert.AreEqual(
                        expected: 25,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Sunday).Day);
                }

                {
                    var year = (UInt16)2015;

                    Assert.AreEqual(
                        expected: 9,
                        actual: year.DayOfYear(WeekOfYear.Second, DayOfWeek.Friday).Day);

                    Assert.AreEqual(
                        expected: 31,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Thursday).Day);

                    Assert.Throws<DateNotFoundException>(
                        () => year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Friday));
                    Assert.AreEqual(
                        expected: 25,
                        actual: year.DayOfYear(WeekOfYear.FiftyThird, DayOfWeek.Friday, true).Day);
                }

            }

        }
    }
}
