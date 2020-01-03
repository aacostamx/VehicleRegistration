using System;
using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class SubmitOrder
    {
        public long OrderNumber { get; set; }
        public string ApplicationId { get; set; }
        public DateTime OrderExpiryDate { get; set; }
        public string CounterParty { get; set; }
        public string PlateNumber { get; set; }
        public string PlateCode { get; set; }
        public int? ProductionYear { get; set; }
        public int? NumberOfHorses { get; set; }
        public bool Diesel { get; set; }
        public int? NetWeight { get; set; }
        public int? VehicleTypeCode { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string TownName { get; set; }
        public string AreaName { get; set; }
        public string FloorNumber { get; set; }
        public string TelephoneOne { get; set; }
        public string TelephoneTwo { get; set; }
        public List<SubmitOrderFee> Fees { get; set; }
        public string RFID_TID { get; set; }
        public bool? ForRent { get; set; }
        public int? InsuranceCompanyCode { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceVignette { get; set; }
        public DateTime? InsuranceDate { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
        public string UserName { get; set; }
    }
}
