using System;


namespace Inkript.VR.Models
{

    public class RegisteredVehicleTypes {
        public virtual int RegisteredCarId { get; set; }
        public virtual int CarUniqueNumber { get; set; }
        public virtual string PlateNumber { get; set; }
        public virtual int? PlateCodeId { get; set; }
        public virtual int FormId { get; set; }
        public virtual int? ColorId { get; set; }
        public virtual int? UtilizationId { get; set; }
        public virtual int? TrunkTypeId { get; set; }
        public virtual int? FuelTypeId { get; set; }
        public virtual string MotorNumber { get; set; }
        public virtual int HorsePower { get; set; }
        public virtual int Cylinders { get; set; }
        public virtual int CapacityCC { get; set; }
        public virtual int? Seats { get; set; }
        public virtual int? SeatsNextDriver { get; set; }
        public virtual int? PassengersNo { get; set; }
        public virtual int? EmptyWeight { get; set; }
        public virtual int? NetWeight { get; set; }
        public virtual int? TotalWeight { get; set; }
        public virtual int? YearMake { get; set; }
        public virtual int VehicleCategoryId { get; set; }
        public virtual int? SectorId { get; set; }
        public virtual int? VehicleTypeId { get; set; }
        public virtual DateTime? InServiceDate { get; set; }
        public virtual DateTime? DateRegistered { get; set; }
        public virtual int? CarStatusId { get; set; }
        public virtual int? BranchId { get; set; }
        public virtual int? StatusId { get; set; }
        public virtual int? ExemptionCategory { get; set; }
        public virtual string Comments { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual string VehicleTypeNameEn { get; set; }
        public virtual string VehicleTypeNameAr { get; set; }
    }
}
