using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class PersonCustom
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string MotherName { get; set; }
        public string MotherMaidenName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int? DrivingLicenceId { get; set; }
        public int? NationalId { get; set; }
        public string Phone { get; set; }
        public int? Floor { get; set; }
        public string PIN { get; set; }
        public string RecordNumber { get; set; }
    }
}