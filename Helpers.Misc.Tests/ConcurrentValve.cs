using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.Tests
{
    [TestClass]
    public class Test_ConcurrentValve
    {
        [TestMethod]
        public void Get()
        {
            var valve = new ConcurrentValve(ConcurrentValve.States.Opened);

            var context = valve.Get(TimeSpan.FromMilliseconds(100));
            Assert.IsNotNull(context);
            Assert.AreEqual(
                expected: valve._state,
                actual: context.Value.State);
            Assert.AreEqual(
                expected: valve._modifiedOn,
                actual: context.Value.ModifiedOn);
        }

        [TestMethod]
        public void Set()
        {
            var valve = new ConcurrentValve(ConcurrentValve.States.Opened);

            var now = DateTimeOffset.Now;
            var context = valve.Set(ConcurrentValve.States.Closed, TimeSpan.FromMilliseconds(100));
            Assert.IsNotNull(context);
            Assert.AreEqual(
                expected: ConcurrentValve.States.Closed,
                actual: context.Value.State);
            Assert.IsTrue(
                context.Value.ModifiedOn > now);
        }

    }
}
