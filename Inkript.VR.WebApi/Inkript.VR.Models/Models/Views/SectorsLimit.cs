namespace Inkript.VR.Models
{

    public class SectorsLimit {
        public virtual int SectorId { get; set; }
        public virtual string SectorNameEn { get; set; }
        public virtual string SectorNameAr { get; set; }
        public virtual int PlateCodeId { get; set; }
        public virtual int? VehicleTypeId { get; set; }
        public virtual int? BranchId { get; set; }
        public virtual int? TotalAvailable { get; set; }
        public virtual string WarningLimit { get; set; }
    }
}
