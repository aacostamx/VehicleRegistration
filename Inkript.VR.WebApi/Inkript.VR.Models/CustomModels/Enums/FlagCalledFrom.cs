using System;

namespace Inkript.VR.Models
{
    [Flags]
    public enum FlagCalledFrom
    {
        UserInterface = 0x01,
        Backend = 0x02
    }
}
