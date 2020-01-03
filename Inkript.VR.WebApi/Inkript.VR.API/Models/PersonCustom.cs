using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class PersonCustom {
        [JsonIgnore]
        public int PersonId { get; set; }
        [Required]
        public int DrivingLicenseId { get; set; }
        [Required]
        public int NationalId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string MotherMaidenName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string CityOfBirth { get; set; }
        [Required]
        public string CountryOfBirth { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Building { get; set; }
        public int? Floor { get; set; }
        public string PIN { get; set; }
        public string AddressDetails { get; set; }
        [Required]
        public string NumberOfRegistry { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
