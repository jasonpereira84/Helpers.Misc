using System;
using System.Collections;
using System.Collections.Generic;

namespace JasonPereira84.Helpers
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

    public interface ITriad<TValue1, TValue2, TValue3>
    {
        TValue1 Value1 { get; }

        TValue2 Value2 { get; }

        TValue3 Value3 { get; }
    }

    public interface IKeyValuePair<TKey, TValue>
    {
        TKey Key { get; }

        TValue Value { get; }
    }
}