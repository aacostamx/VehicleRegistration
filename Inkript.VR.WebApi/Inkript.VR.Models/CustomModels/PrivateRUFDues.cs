using System;
using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class PrivateRUFResult
    {
        public PaymentsInfo PaymentsInfo { get; set; }
        public int DueMonth { get; set; }
    }

    public class PrivateRUFObject
    {
        public PrivateRUFObject()
        {
            CarDetails = new CarDetailsRUF();
            Agent = new Agent();
        }
        public CarDetailsRUF CarDetails { get; set; }
        public Agent Agent { get; set; }
        public int CurrYearIncluded { get; set; }
        public int PaymentType { get; set; }
    }

    public class CarDetailsRUF
    {
        public CarDetailsRUF()
        {
            Owners = new List<PrivateRUFOwners>();
        }
        public int ApplicationNumber { get; set; }
        public string CUN { get; set; }
        public string CarPlateNumber { get; set; }
        public string ProductionYear { get; set; }
        public string CarCode { get; set; }
        public string Sector { get; set; }
        public int UtilizationId { get; set; }
        public string UtilizationDesc { get; set; }
        public string BrandDesc { get; set; }
        public string ModelDesc { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string VehicleType { get; set; }
        public int TrunkTypeId { get; set; }
        public string FuelType { get; set; }
        public int HorsePower { get; set; }
        public int NumberOfCylinders { get; set; }
        public int TotalSeats { get; set; }
        public int SeatsNextToDriver { get; set; }
        public int EmptyWeight { get; set; }
        public int NetWeight { get; set; }
        public int TotalWeight { get; set; }
        public List<PrivateRUFOwners> Owners { get; set; }
    }

    public class PrivateRUFOwners
    {
        public string OwnerType { get; set; }
        public string OwnerName { get; set; }
    }
}
