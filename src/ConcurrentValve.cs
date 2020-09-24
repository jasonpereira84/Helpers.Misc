using System;
using System.Linq;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
{
    using Internal;

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
        private DateTimeOffset _toggledAt;

        public ConcurrentValve(StatesEnum initialState)
        {
            _state = initialState;
            _toggledAt = DateTimeOffset.Now;
        }

        public Nullable<(StatesEnum State, DateTimeOffset ToggledAt)> Set(StatesEnum state, TimeSpan timeout, Action<ApplicationException> onTimeout, Action<Exception> onException)
        {
            var retVal = default(Nullable<(StatesEnum State, DateTimeOffset ToggledAt)>);
            try
            {
                _padlock.AcquireWriterLock(timeout);
                _state = state;
                _toggledAt = DateTimeOffset.Now;
                retVal = (State: _state, ToggledAt: _toggledAt);
            }
            catch (ApplicationException x) when (onTimeout != null) { onTimeout.Invoke(x); }
            catch (Exception x) when (onException != null) { onException.Invoke(x); }
            finally
            {
                if (_padlock.IsWriterLockHeld)
                    _padlock.ReleaseWriterLock();
            }
            return retVal;
        }

        public Nullable<(StatesEnum State, DateTimeOffset ToggledAt)> Get(TimeSpan timeout, Action<ApplicationException> onTimeout, Action<Exception> onException)
        {
            var retVal = default(Nullable<(StatesEnum State, DateTimeOffset ToggledAt)>);
            try
            {
                _padlock.AcquireReaderLock(timeout);
                retVal = (State: _state, ToggledAt: _toggledAt);
            }
            catch (ApplicationException x) when (onTimeout != null) { onTimeout.Invoke(x); }
            catch (Exception x) when (onException != null) { onException.Invoke(x); }
            finally
            {
                if (_padlock.IsReaderLockHeld)
                    _padlock.ReleaseReaderLock();
            }
            return retVal;
        }
    }
}
