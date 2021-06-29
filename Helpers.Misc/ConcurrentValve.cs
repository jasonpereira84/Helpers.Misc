using System;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    public sealed class ConcurrentValve
    {
        [DefaultValue(Unknown)]
        public enum StatesEnum
        {
            Closed = -1,
            Unknown = 0,
            Opened = 1,
        }

        private readonly ReaderWriterLock _padlock = new ReaderWriterLock();

        private StatesEnum _state;
        private DateTimeOffset _modifiedOn;

        public ConcurrentValve(StatesEnum initialState)
        {
            _state = initialState;
            _modifiedOn = DateTimeOffset.Now;
        }

        public Nullable<(StatesEnum State, DateTimeOffset ModifiedOn)> Set(StatesEnum state, TimeSpan timeout, Action<ApplicationException> onTimeout)
        {
            var retVal = default(Nullable<(StatesEnum State, DateTimeOffset ModifiedOn)>);
            try
            {
                _padlock.AcquireWriterLock(timeout);
                _state = state;
                _modifiedOn = DateTimeOffset.Now;
                retVal = (State: _state, ModifiedOn: _modifiedOn);
            }
            catch (ApplicationException x) when (onTimeout != null) { onTimeout.Invoke(x); }
            finally
            {
                if (_padlock.IsWriterLockHeld)
                    _padlock.ReleaseWriterLock();
            }
            return retVal;
        }

        public Nullable<(StatesEnum State, DateTimeOffset ModifiedOn)> Get(TimeSpan timeout, Action<ApplicationException> onTimeout)
        {
            var retVal = default(Nullable<(StatesEnum State, DateTimeOffset ModifiedOn)>);
            try
            {
                _padlock.AcquireReaderLock(timeout);
                retVal = (State: _state, ModifiedOn: _modifiedOn);
            }
            catch (ApplicationException x) when (onTimeout != null) { onTimeout.Invoke(x); }
            finally
            {
                if (_padlock.IsReaderLockHeld)
                    _padlock.ReleaseReaderLock();
            }
            return retVal;
        }

        private void padlock_AcquireWriterLock(TimeSpan timeout) => _padlock.AcquireWriterLock(timeout);
        private void padlock_ReleaseWriterLock()
        {
            var i = 5;
            while (_padlock.IsWriterLockHeld && --i > 0)
                _padlock.ReleaseWriterLock();
        }
        private Boolean padlock_IsWriterLockHeld() => _padlock.IsWriterLockHeld;
    }
}
