using System;

namespace Inkript.VR.Models
{
    public class Owners
    {
        public string Street { get; set; }
        public string Building { get; set; }

        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string RegistrationNumber { get; set; }
        public int RegisterRegionId { get; set; }
        public string MOFNumber { get; set; }
        public int SectorId { get; set; }
        public int CompanyClassId { get; set; }
        public int CompanyCategoryId { get; set; }
        public int RegionId { get; set; }
        public int StatusId { get; set; }

        public int PersonId { get; set; }
        public int? DrivingLicenseId { get; set; }
        public int? NationalId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string MotherMaidenName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public int CityId { get; set; }
        public int? Floor { get; set; }
        public string PIN { get; set; }
        public string AddressDetails { get; set; }
        public string NumberOfRegistry { get; set; }
        public string Phone { get; set; }
    }
}
