using System;
using System.ComponentModel;

namespace JasonPereira84.Helpers
{
    [DefaultValue(Unknown)]
    public enum BuildConfiguration
    {
        Debug = -1,
        Unknown = 0,
        Release = 1
    }
}