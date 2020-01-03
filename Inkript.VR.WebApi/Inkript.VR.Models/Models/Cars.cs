using System;

namespace Inkript.VR.Models
{
    public class Cars
    {
        public virtual int Id { get; set; }
        public virtual string Type { get; set; }
        public virtual int CertificateId { get; set; }
        public virtual int ColorId { get; set; }
        public virtual int Cylinders { get; set; }
        public virtual string Office { get; set; }
        public virtual string YearMake { get; set; }
        public virtual string Value { get; set; }
        public virtual int Taxes { get; set; }
        public virtual bool Discounted { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateModified { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual bool CarRegisteredFlag { get; set; }
        public virtual int ImportId { get; set; }
        public virtual string ImportedName { get; set; }
        public virtual string MotorNumber { get; set; }
        public virtual bool Status { get; set; }
    }
}
