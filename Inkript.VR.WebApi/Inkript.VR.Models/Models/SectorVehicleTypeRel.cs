namespace Inkript.VR.Models
{
    public class SectorVehicleTypeRel
    {
        public virtual int RelId { get; set; }
        public virtual Utilization Utilization { get; set; }
        public virtual Sectors Sectors { get; set; }
        public virtual VehicleTypes VehicleTypes { get; set; }
    }
}
