namespace Inkript.VR.Models
{
    public class CarPlateInfo
    {
        public OldVehiclePlate OldVehiclePlate { get; set; }
        public NewVehiclePlate NewVehiclePlate { get; set; }
        public int IssuePlates { get; set; }
        public int NumberGeneration { get; set; }
    }

    public class OldVehiclePlate
    {
        public string PlateNumber { get; set; }
        public int PlateCodeId { get; set; }
        public int StatusId { get; set; }
        public string ExpiryDate { get; set; }
    }

    public class NewVehiclePlate
    {
        public string PlateNumber { get; set; }
        public int PlateCodeId { get; set; }
        public int StatusId { get; set; }
        public string ExpiryDate { get; set; }
    }
}
