using System;
using System.Collections;
using System.Collections.Generic;

namespace TeamHealth.Helpers
{
    public interface IValue<TValue>
    {
        TValue Value { get; }
    }

    public interface IDyad<TValue1, TValue2>
    {
        TValue1 Value1 { get; }

        TValue2 Value2 { get; }
    }

    public interface IKeyValuePair<TKey, TValue>
    {
        TKey Key { get; }

        TValue Value { get; }
    }
}