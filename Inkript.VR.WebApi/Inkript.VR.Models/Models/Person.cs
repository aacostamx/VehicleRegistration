using System;

namespace Inkript.VR.Models
{
    public class Person
    {
        public virtual int PersonId { get; set; }
        public virtual int? DrivingLicenseId { get; set; }
        public virtual int? NationalId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MotherName { get; set; }
        public virtual string MotherMaidenName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string CityOfBirth { get; set; }
        public virtual string CountryOfBirth { get; set; }
        public virtual int CityId { get; set; }
        public virtual string Street { get; set; }
        public virtual string Building { get; set; }
        public virtual int? Floor { get; set; }
        public virtual string PIN { get; set; }
        public virtual string AddressDetails { get; set; }
        public virtual string NumberOfRegistry { get; set; }
        public virtual string Phone { get; set; }
    }
}
