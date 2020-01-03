using System;

namespace Inkript.VR.Models
{
    [Flags]
    public enum FlagNumberGeneration
    {
        Automatic = 0x01,
        Manual = 0x02,
        Owned = 0x03
    }
}
