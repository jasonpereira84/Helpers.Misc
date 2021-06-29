using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JasonPereira84.Helpers.UnitTests
{
    using State = ConcurrentValve.StatesEnum;

    [TestClass]
    public class Test_ConcurrentValve
    {
        private MethodInfo padlock_AcquireWriterLock = typeof(ConcurrentValve).GetMethod("padlock_AcquireWriterLock", BindingFlags.NonPublic | BindingFlags.Instance);
        private MethodInfo padlock_ReleaseWriterLock = typeof(ConcurrentValve).GetMethod("padlock_ReleaseWriterLock", BindingFlags.NonPublic | BindingFlags.Instance);
        private MethodInfo padlock_IsWriterLockHeld = typeof(ConcurrentValve).GetMethod("padlock_IsWriterLockHeld", BindingFlags.NonPublic | BindingFlags.Instance);

        [TestMethod]
        public void Get()
        {
            {
                var valve = new ConcurrentValve(initialState: State.Opened);
                var result = valve.Get(
                    TimeSpan.FromMilliseconds(100),
                    (ax) => throw new ExceptionWhileTesting("ApplicationException"));
                Assert.IsNotNull(result);
                Assert.AreEqual(State.Opened, result?.State);
            }

            {
                var valve = new ConcurrentValve(initialState: State.Opened);
                padlock_AcquireWriterLock.Invoke(valve, new Object[] { TimeSpan.FromMilliseconds(100) });
                Assert.IsTrue((Boolean)padlock_IsWriterLockHeld.Invoke(valve, new Object[0]));
                var result = valve.Get(
                    TimeSpan.Zero,
                    (ax) => Assert.IsTrue(true));
                Assert.IsNotNull(result);
                Assert.AreEqual(State.Opened, result?.State);
                padlock_ReleaseWriterLock.Invoke(valve, new Object[0]);
                Assert.IsFalse((Boolean)padlock_IsWriterLockHeld.Invoke(valve, new Object[0]));
            }
        }

        [TestMethod]
        public void Set()
        {
            {
                var valve = new ConcurrentValve(initialState: State.Closed);
                var result = valve.Set(
                    State.Opened,
                    TimeSpan.FromMilliseconds(100),
                    (ax) => throw new ExceptionWhileTesting("ApplicationException"));
                Assert.IsNotNull(result);
                Assert.AreEqual(State.Opened, result?.State);
            }

            {
                var valve = new ConcurrentValve(initialState: State.Closed);
                padlock_AcquireWriterLock.Invoke(valve, new Object[] { TimeSpan.FromMilliseconds(100) });
                Assert.IsTrue((Boolean)padlock_IsWriterLockHeld.Invoke(valve, new Object[0]));
                var result = valve.Set(
                    State.Opened,
                    TimeSpan.Zero,
                    (ax) => Assert.IsTrue(true));
                Assert.IsNotNull(result);
                Assert.AreEqual(State.Opened, result?.State);
                padlock_ReleaseWriterLock.Invoke(valve, new Object[0]);
                Assert.IsFalse((Boolean)padlock_IsWriterLockHeld.Invoke(valve, new Object[0]));
            }
        }

    }
}
