using System;
using System.Threading;
using System.ComponentModel;

namespace JasonPereira84.Helpers
{
    public sealed class ConcurrentValve
    {
        [DefaultValue(Unknown)]
        public enum States
        {
            Closed = -1,
            Unknown = 0,
            Opened = 1,
        }

        internal States _state;
        internal DateTimeOffset _modifiedOn;

        internal readonly ReaderWriterLockSlim _padlock;

        public ConcurrentValve(States initialState, LockRecursionPolicy lockRecursionPolicy = LockRecursionPolicy.NoRecursion)
        {
            _state = initialState;
            _modifiedOn = DateTimeOffset.Now;

            _padlock = new ReaderWriterLockSlim(lockRecursionPolicy);
        }

        ~ConcurrentValve()
        {
            if (_padlock != null) 
                _padlock.Dispose();
        }

        public Nullable<(States State, DateTimeOffset ModifiedOn)> Get(TimeSpan timeout)
        {
            var retVal = default(Nullable<(States State, DateTimeOffset ModifiedOn)>);
            if (_padlock.TryEnterReadLock(timeout))
                try
                {
                    retVal = (_state, _modifiedOn);
                }
                finally
                {
                    if (_padlock.IsReadLockHeld)
                        _padlock.ExitReadLock();
                }
            return retVal;
        }

        public Nullable<(States State, DateTimeOffset ModifiedOn)> Set(States state, TimeSpan timeout)
        {
            var retVal = default(Nullable<(States State, DateTimeOffset ModifiedOn)>);
            if (_padlock.TryEnterUpgradeableReadLock(timeout))
                try
                {
                    if (!state.Equals(_state))
                        if (_padlock.TryEnterWriteLock(timeout))
                            try
                            {
                                _state = state;
                                _modifiedOn = DateTimeOffset.Now;
                            }
                            finally
                            {
                                if (_padlock.IsWriteLockHeld)
                                    _padlock.ExitWriteLock();
                            }
                    retVal = (_state, _modifiedOn);
                }
                finally
                {
                    if (_padlock.IsUpgradeableReadLockHeld)
                        _padlock.ExitUpgradeableReadLock();
                }
            return retVal;
        }

    }
}
