using System;
using System.Collections.Generic;

namespace Inkript.VR.Models
{

    public class RegisteredVehicles
    {
        public RegisteredVehicles()
        {
            Owners = new List<Owners>();
            VehicleOwnership = new List<VehicleOwnership>();
        }
        public virtual int RegisteredVehicleId { get; set; }
        public virtual CarUniqueNumber CarUniqueNumber { get; set; }
        public virtual PlateCodes PlateCodes { get; set; }
        public virtual FORM FORM { get; set; }
        public virtual Colors Colors { get; set; }
        public virtual Utilization Utilization { get; set; }
        public virtual TrunkType TrunkType { get; set; }
        public virtual FuelTypes FuelTypes { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public virtual Sectors Sectors { get; set; }
        public virtual VehicleTypes VehicleTypes { get; set; }
        public virtual CarStatus CarStatus { get; set; }
        public virtual Branches Branches { get; set; }
        public virtual Status Status { get; set; }
        public virtual string PlateNumber { get; set; }
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
        public virtual DateTime? InServiceDate { get; set; }
        public virtual DateTime? DateRegistered { get; set; }
        public virtual int? ExemptionCategory { get; set; }
        public virtual string Comments { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public List<Owners> Owners { get; set; }
        public virtual IList<VehicleOwnership> VehicleOwnership { get; set; }
    }
}
