using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Misc.Tests
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
                    var @string = (String)null;
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
                    var @string = default(String);
                    Assert.Throws<ArgumentNullException>(
                        () => @string.IsEmpty());
                }

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
                    var @string = default(String);
                    Assert.Throws<ArgumentNullException>(
                        () => @string.IsWhiteSpace());
                }

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
                    var @string = default(String);
                    Assert.Throws<ArgumentNullException>(
                        () => @string.IsWhiteSpace());
                }

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
                    var @string = "hello";
                    Assert.IsFalse(@string.IsEmptyOrWhiteSpace());
                }
            }
            
            [TestMethod]
            public void EvaluateSanity()
            {
                {
                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: "NULL",
                            actual: @string.EvaluateSanity().Value);
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: "EMPTY",
                            actual: @string.EvaluateSanity().Value);
                    }

                    {
                        var @string = "";
                        Assert.AreEqual(
                            expected: "EMPTY",
                            actual: @string.EvaluateSanity().Value);
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: "WHITESPACE",
                            actual: @string.EvaluateSanity().Value);
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.EvaluateSanity().Value);
                    }

                    {
                        var @string = "hello ";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.EvaluateSanity().Value);
                    }

                    {
                        var @string = "hello ";
                        Assert.AreEqual(
                            expected: "hello ",
                            actual: @string.EvaluateSanity(dontTrim: true).Value);
                    }
                }

                {
                    {
                        var @string = "hello ";
                        Assert.Throws<ArgumentOutOfRangeException>(
                            () => @string.EvaluateSanity(default(String), out String dump));
                    }

                    {
                        var @string = default(String);
                        Assert.IsFalse(@string.EvaluateSanity("name", out String saneValue));
                        Assert.AreEqual(
                            expected: "NULL-name",
                            actual: saneValue);
                    }

                    {
                        var @string = String.Empty;
                        Assert.IsFalse(@string.EvaluateSanity("name", out String saneValue));
                        Assert.AreEqual(
                            expected: "EMPTY-name",
                            actual: saneValue);
                    }

                    {
                        var @string = "";
                        Assert.IsFalse(@string.EvaluateSanity("name", out String saneValue));
                        Assert.AreEqual(
                            expected: "EMPTY-name",
                            actual: saneValue);
                    }

                    {
                        var @string = " ";
                        Assert.IsFalse(@string.EvaluateSanity("name", out String saneValue));
                        Assert.AreEqual(
                            expected: "WHITESPACE-name",
                            actual: saneValue);
                    }

                    {
                        var @string = "hello ";
                        Assert.IsTrue(@string.EvaluateSanity("name", out String saneValue));
                        Assert.AreEqual(
                            expected: "hello",
                            actual: saneValue);
                    }

                    {
                        var @string = "hello ";
                        Assert.IsTrue(@string.EvaluateSanity("name", out String saneValue, dontTrim: true));
                        Assert.AreEqual(
                            expected: "hello ",
                            actual: saneValue);
                    }

                }

            }

            [TestMethod]
            public void Mask()
            {
                {
                    var @string = default(String);
                    Assert.Throws<ArgumentNullException>(
                        () => @string.Mask(0, 10));
                }

                {
                    var @string = String.Empty;
                    Assert.Throws<ArgumentOutOfRangeException>(
                        () => @string.Mask(0, 10));
                }

                {
                    var @string = "";
                    Assert.Throws<ArgumentOutOfRangeException>(
                        () => @string.Mask(0, 10));
                }

                {
                    var @string = "1234567890";

                    Assert.AreEqual(
                            expected: "1234567890",
                            actual: @string.Mask(0, 0));

                    Assert.AreEqual(
                            expected: "**********",
                            actual: @string.Mask(0, 10));

                    Assert.AreEqual(
                            expected: "********90",
                            actual: @string.Mask(0, 8));

                    Assert.AreEqual(
                            expected: "12********",
                            actual: @string.Mask(2, 8));

                    Assert.AreEqual(
                            expected: "12******90",
                            actual: @string.Mask(2, 6));
                }

            }

            [TestMethod]
            public void IfNullOrEmptyOrWhiteSpace()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s){ retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        @string.IfNullOrEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNullOrEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNullOrEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNullOrEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNullOrEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "";
                        @string.IfNullOrEmptyOrWhiteSpace(func);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.IfNullOrEmptyOrWhiteSpace(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNotNullOrEmptyOrWhiteSpace()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        @string.IfNotNullOrEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNotNullOrEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNotNullOrEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNotNullOrEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNotNullOrEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: default(String),
                            actual: @string.IfNotNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: String.Empty,
                            actual: @string.IfNotNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "";
                        @string.IfNotNullOrEmptyOrWhiteSpace(func);
                        Assert.AreEqual(
                            expected: "",
                            actual: @string.IfNotNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: " ",
                            actual: @string.IfNotNullOrEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNullOrEmptyOrWhiteSpace(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNull()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        @string.IfNull(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNull(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNull(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNull(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNull(action);
                        Assert.IsFalse(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNull(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: String.Empty,
                            actual: @string.IfNull(func));
                    }

                    {
                        var @string = "";
                        @string.IfNull(func);
                        Assert.AreEqual(
                            expected: "",
                            actual: @string.IfNull(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: " ",
                            actual: @string.IfNull(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.IfNull(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNotNull()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        @string.IfNotNull(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNotNull(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNotNull(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNotNull(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNotNull(action);
                        Assert.IsTrue(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: default(String),
                            actual: @string.IfNotNull(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNull(func));
                    }

                    {
                        var @string = "";
                        @string.IfNotNull(func);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNull(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNull(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNull(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfEmpty()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfEmpty(action));
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfEmpty(action);
                        Assert.IsFalse(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfEmpty(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfEmpty(func));
                    }

                    {
                        var @string = "";
                        @string.IfEmpty(func);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfEmpty(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: " ",
                            actual: @string.IfEmpty(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.IfEmpty(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNotEmpty()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfNotEmpty(action));
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNotEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNotEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNotEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNotEmpty(action);
                        Assert.IsTrue(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfNotEmpty(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: String.Empty,
                            actual: @string.IfNotEmpty(func));
                    }

                    {
                        var @string = "";
                        @string.IfNotEmpty(func);
                        Assert.AreEqual(
                            expected: "",
                            actual: @string.IfNotEmpty(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotEmpty(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotEmpty(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfWhiteSpace()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfWhiteSpace(action));
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfWhiteSpace(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: String.Empty,
                            actual: @string.IfWhiteSpace(func));
                    }

                    {
                        var @string = "";
                        @string.IfWhiteSpace(func);
                        Assert.AreEqual(
                            expected: "",
                            actual: @string.IfWhiteSpace(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfWhiteSpace(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.IfWhiteSpace(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNotWhiteSpace()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfNotWhiteSpace(action));
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNotWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNotWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNotWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNotWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfNotWhiteSpace(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotWhiteSpace(func));
                    }

                    {
                        var @string = "";
                        @string.IfNotWhiteSpace(func);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotWhiteSpace(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: " ",
                            actual: @string.IfNotWhiteSpace(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotWhiteSpace(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNullOrEmpty()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        @string.IfNullOrEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNullOrEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNullOrEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNullOrEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNullOrEmpty(action);
                        Assert.IsFalse(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmpty(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmpty(func));
                    }

                    {
                        var @string = "";
                        @string.IfNullOrEmpty(func);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNullOrEmpty(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: " ",
                            actual: @string.IfNullOrEmpty(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.IfNullOrEmpty(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNotNullOrEmpty()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        @string.IfNotNullOrEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNotNullOrEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNotNullOrEmpty(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNotNullOrEmpty(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNotNullOrEmpty(action);
                        Assert.IsTrue(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: default(String),
                            actual: @string.IfNotNullOrEmpty(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: String.Empty,
                            actual: @string.IfNotNullOrEmpty(func));
                    }

                    {
                        var @string = "";
                        @string.IfNotNullOrEmpty(func);
                        Assert.AreEqual(
                            expected: "",
                            actual: @string.IfNotNullOrEmpty(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNullOrEmpty(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotNullOrEmpty(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfEmptyOrWhiteSpace()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfEmptyOrWhiteSpace(action));
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "";
                        @string.IfEmptyOrWhiteSpace(func);
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.IfEmptyOrWhiteSpace(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void IfNotEmptyOrWhiteSpace()
            {
                #region Action
                {
                    Boolean retVal;
                    void action(String s) { retVal = true; }

                    {
                        retVal = false;
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfNotEmptyOrWhiteSpace(action));
                    }

                    {
                        retVal = false;
                        var @string = String.Empty;
                        @string.IfNotEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "";
                        @string.IfNotEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = " ";
                        @string.IfNotEmptyOrWhiteSpace(action);
                        Assert.IsFalse(retVal);
                    }

                    {
                        retVal = false;
                        var @string = "hello";
                        @string.IfNotEmptyOrWhiteSpace(action);
                        Assert.IsTrue(retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String func(String s) => $"{true}";

                    {
                        var @string = default(String);
                        Assert.Throws<ArgumentNullException>(
                            () => @string.IfNotEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: String.Empty,
                            actual: @string.IfNotEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "";
                        @string.IfNotEmptyOrWhiteSpace(func);
                        Assert.AreEqual(
                            expected: "",
                            actual: @string.IfNotEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: " ",
                            actual: @string.IfNotEmptyOrWhiteSpace(func));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: $"{true}",
                            actual: @string.IfNotEmptyOrWhiteSpace(func));
                    }
                }
                #endregion  Func

            }

            [TestMethod]
            public void If()
            {
                #region Action
                {
                    String retVal;
                    void actionIfNull(String s) { retVal = "NULL"; }
                    void actionIfEmpty(String s) { retVal = "EMPTY"; }
                    void actionIfWhiteSpace(String s) { retVal = "WHITESPACE"; }
                    void actionIfNotNullOrEmptyOrWhiteSpace(String s) { retVal = s; }

                    {
                        retVal = default(String);
                        var @string = default(String);
                        @string.If(actionIfNull, actionIfEmpty, actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
                        Assert.AreEqual(
                            expected: "NULL",
                            actual: retVal);
                    }

                    {
                        retVal = default(String);
                        var @string = String.Empty;
                        @string.If(actionIfNull, actionIfEmpty, actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
                        Assert.AreEqual(
                            expected: "EMPTY",
                            actual: retVal);
                    }

                    {
                        retVal = default(String);
                        var @string = "";
                        @string.If(actionIfNull, actionIfEmpty, actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
                        Assert.AreEqual(
                            expected: "EMPTY",
                            actual: retVal);
                    }

                    {
                        retVal = default(String);
                        var @string = " ";
                        @string.If(actionIfNull, actionIfEmpty, actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
                        Assert.AreEqual(
                            expected: "WHITESPACE",
                            actual: retVal);
                    }

                    {
                        retVal = default(String);
                        var @string = "hello";
                        @string.If(actionIfNull, actionIfEmpty, actionIfWhiteSpace, actionIfNotNullOrEmptyOrWhiteSpace);
                        Assert.AreEqual(
                            expected: "hello",
                            actual: retVal);
                    }
                }
                #endregion  Action

                #region Func
                {
                    String funcIfNull(String s) => "NULL";
                    String funcIfEmpty(String s) => "EMPTY";
                    String funcIfWhiteSpace(String s) => "WHITESPACE";
                    String funcIfNotNullOrEmptyOrWhiteSpace(String s) => s;

                    {
                        var @string = default(String);
                        Assert.AreEqual(
                            expected: "NULL",
                            actual: @string.If(funcIfNull, funcIfEmpty, funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace));
                    }

                    {
                        var @string = String.Empty;
                        Assert.AreEqual(
                            expected: "EMPTY",
                            actual: @string.If(funcIfNull, funcIfEmpty, funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace));
                    }

                    {
                        var @string = "";
                        Assert.AreEqual(
                            expected: "EMPTY",
                            actual: @string.If(funcIfNull, funcIfEmpty, funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace));
                    }

                    {
                        var @string = " ";
                        Assert.AreEqual(
                            expected: "WHITESPACE",
                            actual: @string.If(funcIfNull, funcIfEmpty, funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace));
                    }

                    {
                        var @string = "hello";
                        Assert.AreEqual(
                            expected: "hello",
                            actual: @string.If(funcIfNull, funcIfEmpty, funcIfWhiteSpace, funcIfNotNullOrEmptyOrWhiteSpace));
                    }
                }
                #endregion  Func

            }

        }
    }
}
