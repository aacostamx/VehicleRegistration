namespace Inkript.VR.Models
{
    public class BPSectorVehicle
    {
        public virtual int BPSectorVehicleId { get; set; }
        public virtual int BPId { get; set; }
        public virtual int SectorId { get; set; }
        public virtual int VehicleTypeId { get; set; }
    }
}
