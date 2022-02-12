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
        public class Test_PredicatedOn
        {
            [TestMethod]
            public void PredicatedOn()
            {
                {
                    var valueIfTrue = new SomeClass { Value = 1 };
                    var valueIfFalse = new SomeClass { Value = -1 };
                    Assert.AreSame(
                        Misc.PredicatedOn(true, valueIfTrue, valueIfFalse),
                        valueIfTrue);
                    Assert.AreSame(
                        Misc.PredicatedOn(false, valueIfTrue, valueIfFalse),
                        valueIfFalse);
                }

                {
                    var valueIfTrue = new SomeClass { Value = 1 };
                    var valueIfFalse = new SomeClass { Value = -1 };
                    Assert.AreSame(
                        Misc.PredicatedOn(true, () => valueIfTrue, () => valueIfFalse),
                        valueIfTrue);
                    Assert.AreSame(
                        Misc.PredicatedOn(false, () => valueIfTrue, () => valueIfFalse),
                        valueIfFalse);
                }

                {
                    {
                        var source = new SomeClass();
                        Misc.PredicatedOn(true, source, x => { x.Value = 1; }, x => { x.Value = -1; });
                        Assert.IsTrue(source.Value == 1);
                    }

                    {
                        var source = new SomeClass();
                        Misc.PredicatedOn(false, source, x => { x.Value = 1; }, x => { x.Value = -1; });
                        Assert.IsTrue(source.Value == -1);
                    }
                }

                {
                    {
                        var source = new SomeClass();
                        var valueIfTrue = new OtherClass { Value = 1 };
                        var valueIfFalse = new OtherClass { Value = -1 };
                        Assert.AreSame(
                            expected: valueIfTrue,
                            actual: Misc.PredicatedOn(true, source, x => { x.Value = 1; return valueIfTrue; }, x => { x.Value = -1; return valueIfFalse; }));
                        Assert.IsTrue(source.Value == 1);
                    }

                    {
                        var source = new SomeClass();
                        var valueIfTrue = new OtherClass { Value = 1 };
                        var valueIfFalse = new OtherClass { Value = -1 };
                        Assert.AreSame(
                            expected: valueIfFalse,
                            actual: Misc.PredicatedOn(false, source, x => { x.Value = 1; return valueIfTrue; }, x => { x.Value = -1; return valueIfFalse; }));
                        Assert.IsTrue(source.Value == -1);
                    }
                }

            }

        }
    }
}
