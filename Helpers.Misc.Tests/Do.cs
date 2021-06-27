using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.UnitTests
{
    [TestClass]
    public class Test_Do
    {
        [TestMethod]
        public void Nothing()
        {
            //struct
            {
                var source = Struct.From(0);
                Do.Nothing(source);
                Assert.AreEqual(0, source.Value);
            }

            //class
            {
                var source = Class.From(0);
                Do.Nothing(source);
                Assert.AreEqual(0, source.Value);
            }
        }

        [TestMethod]
        public void NothingWith()
        {
            //struct
            {
                var source = Struct.From(0);
                var result = Do.NothingWith(source);
                Assert.AreEqual(0, source.Value);
            }

            //class
            {
                var source = Class.From(0);
                var result = Do.NothingWith(source);
                Assert.AreEqual(0, source.Value);
            }
        }

        [TestMethod]
        public void Action()
        {
            //struct
            {
                var source = Struct.From(0);
                var result = Do.Action(source, x => { x.Value+=1; return x.Value + 1; });
                Assert.AreEqual(1, source.Value);
                Assert.AreEqual(2, result);
            }

            //class
            {
                var source = Class.From(0);
                var result = Do.Action(source, x => { x.Value += 1; return x.Value + 1; });
                Assert.AreEqual(1, source.Value);
                Assert.AreEqual(2, result);
            }
        }
    }
}
