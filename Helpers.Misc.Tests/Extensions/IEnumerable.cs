using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_IEnumerable
        {
            [TestMethod]
            public void None()
            {
                {
                    var source = new Int32[0];

                    Assert.IsTrue(source.None());
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsFalse(source.None());
                }

                {
                    var source = new[] { 1, 2, 3 };
                    var retVal = source.Any(x => x != 2);
                    Assert.IsFalse(source.None());
                }

            }

            [TestMethod]
            public void ContainsAny()
            {
                {
                    var source = new Int32[0];

                    Assert.IsFalse(source.ContainsAny(new[] { 4, 5 }));
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsFalse(source.ContainsAny(new[] { 4, 5 }));
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsTrue(source.ContainsAny(new[] { 4, 1 }));
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsTrue(source.ContainsAny(new[] { 1, 2 }));
                }

            }

            [TestMethod]
            public void ContainsAll()
            {
                {
                    var source = new Int32[0];

                    Assert.IsFalse(source.ContainsAll(new[] { 4, 5 }));
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsFalse(source.ContainsAll(new[] { 4, 5 }));
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsFalse(source.ContainsAll(new[] { 4, 1 }));
                }

                {
                    var source = new[] { 1, 2, 3 };

                    Assert.IsTrue(source.ContainsAll(new[] { 1, 2 }));
                }

            }

            [TestMethod]
            public void FirstOrDefault()
            {
                #region class
                {
                    var source = new SomeClass[0];

                    Assert.AreEqual(
                        expected: new SomeClass { Value = 2 },
                        actual: source.FirstOrDefault(new SomeClass { Value = 2 }));
                }

                {
                    var source = new[] {
                        new SomeClass { Value = 1 }
                    };

                    Assert.AreEqual(
                        expected: new SomeClass { Value = 1 },
                        actual: source.FirstOrDefault(new SomeClass { Value = 2 }));
                }

                {
                    var source = new[] {
                        new SomeClass { Value = 1 }
                    };

                    Assert.AreEqual(
                        expected: new SomeClass { Value = 2 },
                        actual: source.FirstOrDefault(
                            predicate: x => false,
                            defaultValue: new SomeClass { Value = 2 }));
                }

                {
                    var source = new[] {
                        new SomeClass { Value = 1 }
                    };

                    Assert.AreEqual(
                        expected: new SomeClass { Value = 1 },
                        actual: source.FirstOrDefault(
                            predicate: x => true,
                            defaultValue: new SomeClass { Value = 2 }));
                }
                #endregion class

                #region Nullable<struct>
                {
                    var source = new Nullable<Int32>[0];

                    Assert.AreEqual(
                        expected: (Nullable<Int32>)2,
                        actual: source.FirstOrDefault((Nullable<Int32>)2));
                }

                {
                    var source = new[] {
                        (Nullable<Int32>)1
                    };

                    Assert.AreEqual(
                        expected: (Nullable<Int32>)1,
                        actual: source.FirstOrDefault((Nullable<Int32>)2));
                }

                {
                    var source = new[] {
                        (Nullable<Int32>)1
                    };

                    Assert.AreEqual(
                        expected: (Nullable<Int32>)2,
                        actual: source.FirstOrDefault(
                            predicate: x => false,
                            defaultValue: (Nullable<Int32>)2));
                }

                {
                    var source = new[] {
                        (Nullable<Int32>)1
                    };

                    Assert.AreEqual(
                        expected: (Nullable<Int32>)1,
                        actual: source.FirstOrDefault(
                            predicate: x => true,
                            defaultValue: (Nullable<Int32>)2));
                }
                #endregion Nullable<struct>

            }

            [TestMethod]
            public void Each()
            {
                #region Action
                {
                    var source = new[] { 1 };

                    var list = new List<Int32>();
                    source.Each(item => list.Add(item));
                    Assert.IsTrue(list.Count() == 1);
                }
                #endregion Action

                #region Predicate Action
                {
                    var source = new[] { 1, 2 };

                    var list = new List<Int32>();
                    source.Each(
                        predicate: item => item == 2,
                        action: item => list.Add(item));
                    Assert.IsTrue(list.Count() == 1);
                }
                #endregion Predicate Action
            }

            [TestMethod]
            public void Concat()
            {
                {
                    var first = new[] { 1 };

                    var retVal = first.Concat(new[] { 2 }, new[] { 3 });
                    Assert.IsTrue(retVal.Count() == 3);
                }

                {
                    var retVal = Misc.Concat(new[] { 2 }, new[] { 3 });
                    Assert.IsTrue(retVal.Count() == 2);
                }
            }

            [TestMethod]
            public void AsString()
            {
                #region String
                {
                    var source = new[] { 1, 2, 3 };

                    Assert.AreEqual(
                        expected: "1, 2, 3",
                        actual: source.AsString(", "));

                    Assert.AreEqual(
                        expected: "123",
                        actual: source.AsString());
                }
                #endregion String

                #region Char
                {
                    var source = new[] { 1, 2, 3 };

                    Assert.AreEqual(
                        expected: "1,2,3",
                        actual: source.AsString(','));
                }
                #endregion Char

                #region Strings
                {
                    var source = new[] { "1", "2", "3" };

                    Assert.AreEqual(
                        expected: "1, 2, 3",
                        actual: source.AsString(", "));

                    Assert.AreEqual(
                        expected: "123",
                        actual: source.AsString());

                    Assert.AreEqual(
                        expected: "1,2,3",
                        actual: source.AsString(','));
                }
                #endregion Strings
            }

            [TestMethod]
            public void Sanitize()
            {
                {
                    var source = new[] {
                        new KeyValuePair<Int32, String>(1, default),
                        new KeyValuePair<Int32, String>(2, "2") };

                    var retVal = source.Sanitize();
                    Assert.IsTrue(retVal.Count() == 1);
                    Assert.AreEqual(
                        expected: new KeyValuePair<Int32, String>(2, "2"),
                        actual: retVal.First());
                }

                {
                    var source = new[] {
                        new KeyValuePair<Int32, String>(1, default),
                        new KeyValuePair<Int32, String>(2, "") };

                    var retVal = source.Sanitize(
                        x => x != null);
                    Assert.IsTrue(retVal.Count() == 1);
                    Assert.AreEqual(
                        expected: new KeyValuePair<Int32, String>(2, ""),
                        actual: retVal.First());
                }

                {
                    var source = new[] {
                        new KeyValuePair<String, Int32>(default, 1),
                        new KeyValuePair<String, Int32>("2", 2) };

                    var retVal = source.Sanitize();
                    Assert.IsTrue(retVal.Count() == 1);
                    Assert.AreEqual(
                        expected: new KeyValuePair<String, Int32>("2", 2),
                        actual: retVal.First());
                }

                {
                    var source = new[] {
                        new KeyValuePair<String, Int32>(default, 1),
                        new KeyValuePair<String, Int32>("", 2) };

                    var retVal = source.Sanitize(
                        x => x != null);
                    Assert.IsTrue(retVal.Count() == 1);
                    Assert.AreEqual(
                        expected: new KeyValuePair<String, Int32>("", 2),
                        actual: retVal.First());
                }

            }

        }
    }
}
