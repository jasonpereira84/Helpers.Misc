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
        public class Test_TDictionary
        {
            [TestMethod]
            public void Add()
            {
                #region params KeyValuePair[]
                {
                    var dictionary = new Dictionary<Int32, Int32>();

                    dictionary.Add(
                        new KeyValuePair<Int32, Int32>(1, 1));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.Add(
                        new KeyValuePair<Int32, Int32>(2, 1));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion params KeyValuePair[]

                #region IEnumerable<KeyValuePair>
                {
                    var dictionary = new Dictionary<Int32, Int32>();

                    dictionary.Add(
                        new[] {
                            new KeyValuePair<Int32, Int32>(1, 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.Add(
                        new[] {
                            new KeyValuePair<Int32, Int32>(2, 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion IEnumerable<KeyValuePair>

                #region params Tuple[]
                {
                    var dictionary = new Dictionary<Int32, Int32>();

                    dictionary.Add(
                        (Key: 1, Value: 1));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.Add(
                        (Key: 2, Value: 1));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion params Tuple[]

                #region IEnumerable<Tuple>
                {
                    var dictionary = new Dictionary<Int32, Int32>();

                    dictionary.Add(
                        new[] {
                            (Key: 1, Value: 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.Add(
                        new[] {
                            (Key: 2, Value: 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion IEnumerable<Tuple>
            }

            [TestMethod]
            public void AddIfNew()
            {
                #region params KeyValuePair[]
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNew(
                        new KeyValuePair<Int32, Int32>(1, 1));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.AddIfNew(
                        new KeyValuePair<Int32, Int32>(2, 1));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion params KeyValuePair[]

                #region IEnumerable<KeyValuePair>
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNew(
                        new[] {
                            new KeyValuePair<Int32, Int32>(1, 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.AddIfNew(
                        new[] {
                            new KeyValuePair<Int32, Int32>(2, 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion IEnumerable<KeyValuePair>

                #region params Tuple[]
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNew(
                        (Key: 1, Value: 1));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.AddIfNew(
                        (Key: 2, Value: 1));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion params Tuple[]

                #region IEnumerable<Tuple>
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNew(
                        new[] {
                            (Key: 1, Value: 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 1);

                    dictionary.AddIfNew(
                        new[] {
                            (Key: 2, Value: 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);
                }
                #endregion IEnumerable<Tuple>
            }

            [TestMethod]
            public void AddIfNewOrUpdate()
            {
                #region params KeyValuePair[]
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNewOrUpdate(
                        new KeyValuePair<Int32, Int32>(2, 1));
                    Assert.IsTrue(dictionary.Count() == 2);

                    dictionary.AddIfNewOrUpdate(
                        new KeyValuePair<Int32, Int32>(2, 2));
                    Assert.IsTrue(dictionary.Count() == 2);
                    Assert.AreEqual(
                        expected: 2,
                        actual: dictionary[2]);
                }
                #endregion params KeyValuePair[]

                #region IEnumerable<KeyValuePair>
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNewOrUpdate(
                        new[] {
                            new KeyValuePair<Int32, Int32>(2, 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);

                    dictionary.AddIfNewOrUpdate(
                        new[] {
                            new KeyValuePair<Int32, Int32>(2, 2)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);
                    Assert.AreEqual(
                        expected: 2,
                        actual: dictionary[2]);
                }
                #endregion IEnumerable<KeyValuePair>

                #region params Tuple[]
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNewOrUpdate(
                        (Key: 2, Value: 1));
                    Assert.IsTrue(dictionary.Count() == 2);

                    dictionary.AddIfNewOrUpdate(
                        (Key: 2, Value: 2));
                    Assert.IsTrue(dictionary.Count() == 2);
                    Assert.AreEqual(
                        expected: 2,
                        actual: dictionary[2]);
                }
                #endregion params Tuple[]

                #region IEnumerable<Tuple>
                {
                    var dictionary = new Dictionary<Int32, Int32>
                    {
                        new KeyValuePair<Int32,Int32>(1, 1)
                    };

                    dictionary.AddIfNewOrUpdate(
                        new[] {
                            (Key: 2, Value: 1)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);

                    dictionary.AddIfNewOrUpdate(
                        new[] {
                            (Key: 2, Value: 2)
                        }.Select(x => x));
                    Assert.IsTrue(dictionary.Count() == 2);
                    Assert.AreEqual(
                        expected: 2,
                        actual: dictionary[2]);
                }
                #endregion IEnumerable<Tuple>
            }

            [TestMethod]
            public void TryGetValueOrDefault()
            {
                var dictionary = new Dictionary<Int32, Int32>
                {
                    new KeyValuePair<Int32,Int32>(1, 1)
                };

                {
                    var @bool = dictionary.TryGetValueOrDefault(1, out Int32 value);
                    Assert.IsTrue(@bool);
                    Assert.AreEqual(
                        expected: 1,
                        actual: value);
                }

                {
                    var @bool = dictionary.TryGetValueOrDefault(2, out Int32 value);
                    Assert.IsFalse(@bool);
                    Assert.AreEqual(
                        expected: default(Int32),
                        actual: value);
                }

                {
                    var @bool = dictionary.TryGetValueOrDefault(2, out Int32 value, 1);
                    Assert.IsFalse(@bool);
                    Assert.AreEqual(
                        expected: 1,
                        actual: value);
                }
            }

            [TestMethod]
            public void ReallyTryGetValueOrDefault()
            {
                var dictionary = new Dictionary<String, Int32>
                {
                    new KeyValuePair<String,Int32>("a", 1)
                };

                {
                    var @bool = dictionary.ReallyTryGetValueOrDefault("a", out Int32 value);
                    Assert.IsTrue(@bool);
                    Assert.AreEqual(
                        expected: 1,
                        actual: value);
                }

                {
                    var @bool = dictionary.ReallyTryGetValueOrDefault("b", out Int32 value);
                    Assert.IsFalse(@bool);
                    Assert.AreEqual(
                        expected: default(Int32),
                        actual: value);
                }

                {
                    var @bool = dictionary.ReallyTryGetValueOrDefault("b", out Int32 value, 1);
                    Assert.IsFalse(@bool);
                    Assert.AreEqual(
                        expected: 1,
                        actual: value);
                }

                {
                    var @bool = dictionary.ReallyTryGetValueOrDefault("A", out Int32 value);
                    Assert.IsTrue(@bool);
                    Assert.AreEqual(
                        expected: 1,
                        actual: value);
                }

                {
                    var @bool = dictionary.ReallyTryGetValueOrDefault("B", out Int32 value);
                    Assert.IsFalse(@bool);
                    Assert.AreEqual(
                        expected: default(Int32),
                        actual: value);
                }

                {
                    var @bool = dictionary.ReallyTryGetValueOrDefault("B", out Int32 value, 1);
                    Assert.IsFalse(@bool);
                    Assert.AreEqual(
                        expected: 1,
                        actual: value);
                }
            }

        }
    }
}
