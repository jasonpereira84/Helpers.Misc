using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JasonPereira84.Helpers.Tests
{
    [TestClass]
    public class Test_Do
    {
        [TestMethod]
        public void NothingWith()
        {
            var source = "hello";
            Assert.AreSame(
                expected: source,
                actual: Do.NothingWith(source));
        }

        [TestMethod]
        public void Action()
        {
            {
                var source = new SomeClass { Value = 1 };
                Do.Action(source, x => { x.Value += 1; });
                Assert.IsTrue(source.Value == 2);
            }

            {
                {
                    var source = new SomeClass { Value = 1 };
                    var result = Do.Action(source, x => { x.Value += 1; return x; });
                    Assert.AreSame(source, result);
                    Assert.IsTrue(result.Value == 2);
                }

                {
                    var source = new SomeClass { Value = 1 };
                    var result = Do.Action(source, x => { return new OtherClass { Value = x.Value + 1 }; });
                    Assert.IsTrue(result.Value == 2);
                }
            }
        }

    }
}
