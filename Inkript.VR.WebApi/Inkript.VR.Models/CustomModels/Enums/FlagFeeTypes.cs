using System;

namespace Inkript.VR.Models
{
    [Flags]
    public enum FlagFeeTypes
    {
        Fixed = 0x01,
        StoredProcedure = 0x02,
        Api = 0x03
    }
}
