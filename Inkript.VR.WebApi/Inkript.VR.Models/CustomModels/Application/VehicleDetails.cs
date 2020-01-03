using System;

namespace Inkript.VR.Models
{
    public class VehicleDetails
    {

        public VehicleDetails()
        {
            RUF = new RUF
            {
                CurrentYearIncluded = null,
                DiscountPercentage = null,
                DiscountAmount = null
            };
            Mortgage = new Mortgage
            {
                ReferenceNumber = null
            };
        }

        public string CertificateId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? ProductionYear { get; set; }
        public int? ColorId { get; set; }
        public string Comments { get; set; }
        public string Chassis { get; set; }
        public string MotorNumber { get; set; }
        public int? Cylinders { get; set; }
        public double? Taxes { get; set; }
        public int? Discounted { get; set; }

        public int? CarUniqueNumber { get; set; }
        public int? TrimId { get; set; }
        public string PlateNumber { get; set; }
        public int? PlateCodeId { get; set; }
        public int? FormId { get; set; }
        public string ForRent { get; set; }
        public int? TrunkTypeId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? HorsePower { get; set; }
        public int? CapacityCC { get; set; }
        public int? Seats { get; set; }
        public int? SeatsNextDriver { get; set; }
        public int? PassengersNo { get; set; }
        public int? EmptyWeight { get; set; }
        public double? EnginePrice { get; set; }
        public int? NetWeight { get; set; }
        public int? NumberOfDelayedWeeks { get; set; }
        public int? YearMake { get; set; }
        public int? VehicleCategoryId { get; set; }
        public int? SectorId { get; set; }
        public int? TotalWeight { get; set; }
        public int? VehicleTypeId { get; set; }
        public DateTime? InServiceDate { get; set; }
        public DateTime? DateRegistered { get; set; }
        public int? CarStatusId { get; set; }
        public int? ExemptionCategory { get; set; }
        public int? UtilizationId { get; set; }
        public int? TrunkPrice { get; set; }

        public double Value { get; set; }

        public int IsRegistered { get; set; }
        public double? MarginRate { get; set; }

        public RUF RUF { get; set; }
        public Mortgage Mortgage { get; set; }
    }

    public class RUF
    {
        public int? CurrentYearIncluded { get; set; }
        public string DiscountPercentage { get; set; }
        public int? DiscountAmount { get; set; }
    }

    public class Mortgage
    {
        public string ReferenceNumber { get; set; }
    }
}