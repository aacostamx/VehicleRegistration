using System;

namespace Inkript.VR.Models
{
    [Flags]
    public enum FlagVehicleType
    {
        All = 0x00,
        Bus = 0x01,
        Truck = 0x02,
        Car = 0x03,
        Motorcycle = 0x04,
        Tractor = 0x05,
        PublicWorks = 0x06,
        HeavyEquipment = 0x07
    }
}
