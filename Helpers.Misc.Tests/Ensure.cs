using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JasonPereira84.Helpers.UnitTests
{
    [TestClass]
    public class Test_Ensure
    {
        private const Boolean Success = true;
        private const Boolean Failure = false;

        [TestMethod]
        public void That()
        {
            try 
            {
                Ensure.That<SomeException>(Success);
                Assert.IsTrue(true);//made it here, i.e Exception not thrown

                Ensure.That<SomeException>(Failure);
            }
            catch (SomeException) { }

            try
            {
                Ensure.That<SomeException>(Failure, new object[] { "hello", new SomeException("world") });
            }
            catch (SomeException x)
            {
                Assert.AreEqual("hello", x.Message);
                Assert.IsInstanceOfType(x.InnerException, typeof(SomeException));
                Assert.AreEqual("world", x.InnerException.Message);
            }
        }

        [TestMethod]
        public void Argument()
        {
            try { Ensure.Argument.Is(Failure); }
            catch (ArgumentException) { }

            try { Ensure.Argument.Is(Failure, "hello"); }
            catch (ArgumentException x)
            {
                Assert.AreEqual("hello", x.Message);
            }

            try { Ensure.Argument.Is(Failure, "hello", "world"); }
            catch (ArgumentException x)
            {
                Assert.AreEqual("hello (Parameter 'world')", x.Message);
                Assert.AreEqual("world", x.ParamName);
            }
        }

    }
}
