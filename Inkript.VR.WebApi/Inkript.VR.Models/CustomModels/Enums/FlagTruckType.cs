using System;

namespace Inkript.VR.Models
{
    [Flags]
    public enum FlagTruckType
    {
        Normal = 0x01,
        LocomotiveAndTrailer = 0x02,
        LocomotiveAndHalfTrailer = 0x03
    }
}
