using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class RegisteredVehicleTypesCustom {
        public int RegisteredCarId { get; set; }
        public int CarUniqueNumber { get; set; }
        public string PlateNumber { get; set; }
        public int? PlateCodeId { get; set; }
        public int FormId { get; set; }
        public int? ColorId { get; set; }
        public int? UtilizationId { get; set; }
        public int? TrunkTypeId { get; set; }
        public int? FuelTypeId { get; set; }
        public string MotorNumber { get; set; }
        public int HorsePower { get; set; }
        public int Cylinders { get; set; }
        public int CapacityCC { get; set; }
        public int? Seats { get; set; }
        public int? SeatsNextDriver { get; set; }
        public int? PassengersNo { get; set; }
        public int? EmptyWeight { get; set; }
        public int? NetWeight { get; set; }
        public int? TotalWeight { get; set; }
        public int? YearMake { get; set; }
        public int VehicleCategoryId { get; set; }
        public int? SectorId { get; set; }
        public int? VehicleTypeId { get; set; }
        public DateTime? InServiceDate { get; set; }
        public DateTime? DateRegistered { get; set; }
        public int? CarStatusId { get; set; }
        public int? BranchId { get; set; }
        public int? StatusId { get; set; }
        public int? ExemptionCategory { get; set; }
        public string Comments { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string VehicleTypeNameEn { get; set; }
        public string VehicleTypeNameAr { get; set; }
    }
}
