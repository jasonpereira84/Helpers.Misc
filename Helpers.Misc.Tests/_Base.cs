using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]
namespace JasonPereira84.Helpers.Misc.Tests
{
    internal class SomeClass : IEquatable<SomeClass>
    {
        public Int32 Value { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SomeClass);
        }

        public bool Equals(SomeClass other)
        {
            if (other == null)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            {
                hash.Add(Value);
            }
            return hash.ToHashCode();
        }

        public static bool operator ==(SomeClass left, SomeClass right)
        {
            return EqualityComparer<SomeClass>.Default.Equals(left, right);
        }

        public static bool operator !=(SomeClass left, SomeClass right)
        {
            return !(left == right);
        }

    }

    internal class OtherClass : IEquatable<OtherClass>
    {
        public Int32 Value { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as OtherClass);
        }

        public bool Equals(OtherClass other)
        {
            if (other == null)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            {
                hash.Add(Value);
            }
            return hash.ToHashCode();
        }

        public static bool operator ==(OtherClass left, OtherClass right)
        {
            return EqualityComparer<OtherClass>.Default.Equals(left, right);
        }

        public static bool operator !=(OtherClass left, OtherClass right)
        {
            return !(left == right);
        }

    }

    internal class SomeException : Exception
    {
        public SomeException() : base() { }
        public SomeException(string message) : base(message) { }
        public SomeException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class ExceptionWhileTesting : Exception
    {
        public ExceptionWhileTesting(string message) : base(message) { }
    }

}
