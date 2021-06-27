using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.UnitTests
{
    namespace Extensions
    {
        using JasonPereira84.Helpers.Extensions;

        [TestClass]
        public class Test_String
        {
            [TestMethod]
            public void IsNull()
            {
                {
                    var @string = default(String);
                    Assert.IsTrue(@string.IsNull());
                }

                {
                    var @string = "hello";
                    Assert.IsFalse(@string.IsNull());
                }
            }

            [TestMethod]
            public void IsEmpty()
            {
                {
                    var @string = "";
                    Assert.IsTrue(@string.IsEmpty());
                }
                {
                    var @string = String.Empty;
                    Assert.IsTrue(@string.IsEmpty());
                }

                {
                    var @string = " ";
                    Assert.IsFalse(@string.IsEmpty());
                }

                {
                    var @string = "hello";
                    Assert.IsFalse(@string.IsEmpty());
                }
            }

            [TestMethod]
            public void IsWhiteSpace()
            {
                {
                    var @string = " ";
                    Assert.IsTrue(@string.IsWhiteSpace());
                }

                {
                    var @string = "";
                    Assert.IsFalse(@string.IsWhiteSpace());
                }

                {
                    var @string = "hello";
                    Assert.IsFalse(@string.IsWhiteSpace());
                }
            }

            [TestMethod]
            public void IsNullOrEmpty()
            {
                {
                    var @string = default(String);
                    Assert.IsTrue(@string.IsNullOrEmpty());
                }
                {
                    var @string = String.Empty;
                    Assert.IsTrue(@string.IsNullOrEmpty());
                }
                {
                    var @string = "";
                    Assert.IsTrue(@string.IsNullOrEmpty());
                }

                {
                    var @string = " ";
                    Assert.IsFalse(@string.IsNullOrEmpty());
                }

                {
                    var @string = "hello";
                    Assert.IsFalse(@string.IsNullOrEmpty());
                }
            }

            [TestMethod]
            public void IsEmptyOrWhiteSpace()
            {
                {
                    var @string = String.Empty;
                    Assert.IsTrue(@string.IsEmptyOrWhiteSpace());
                }
                {
                    var @string = "";
                    Assert.IsTrue(@string.IsEmptyOrWhiteSpace());
                }
                {
                    var @string = " ";
                    Assert.IsTrue(@string.IsEmptyOrWhiteSpace());
                }

                {
                    var @string = default(String);
                    Assert.IsFalse(@string.IsEmptyOrWhiteSpace());
                }
                {
                    var @string = "hello";
                    Assert.IsFalse(@string.IsEmptyOrWhiteSpace());
                }
            }

            [TestMethod]
            public void IsEmptyIsNullOrEmptyOrWhiteSpaceOrWhiteSpace()
            {
                {
                    var @string = default(String);
                    Assert.IsTrue(@string.IsNullOrEmptyOrWhiteSpace());
                }
                {
                    var @string = String.Empty;
                    Assert.IsTrue(@string.IsNullOrEmptyOrWhiteSpace());
                }
                {
                    var @string = "";
                    Assert.IsTrue(@string.IsNullOrEmptyOrWhiteSpace());
                }
                {
                    var @string = " ";
                    Assert.IsTrue(@string.IsNullOrEmptyOrWhiteSpace());
                }

                {
                    var @string = "hello";
                    Assert.IsFalse(@string.IsNullOrEmptyOrWhiteSpace());
                }
            }

            [TestMethod]
            public void EvaluateSanity()
            {
                {
                    var @string = default(String);
                    Assert.AreEqual("NULL", @string.EvaluateSanity().Value);
                }
                {
                    var @string = String.Empty;
                    Assert.AreEqual("EMPTY", @string.EvaluateSanity().Value);
                }
                {
                    var @string = "";
                    Assert.AreEqual("EMPTY", @string.EvaluateSanity().Value);
                }
                {
                    var @string = " ";
                    Assert.AreEqual("WHITESPACE", @string.EvaluateSanity().Value);
                }

                {
                    var @string = "hello";
                    Assert.AreEqual("hello", @string.EvaluateSanity().Value);
                }
                {
                    var @string = "hello ";
                    Assert.AreEqual("hello", @string.EvaluateSanity().Value);
                }
                {
                    var @string = "hello ";
                    Assert.AreEqual("hello ", @string.EvaluateSanity(dontTrim: true).Value);
                }
            }

        }
    }
}
