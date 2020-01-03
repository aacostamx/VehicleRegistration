using System;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{

    public class ImportCustoms {
        public virtual int ImportCustomId { get; set; }
        [IgnoreDataMember]
        public int FileInfoCustomId { get; set; }
        public virtual FileInfoCustoms FileInfoCustoms { get; set; }
        public virtual DateTime? CertificateDate { get; set; }
        public virtual string OperationType { get; set; }
        public virtual string CertificateId { get; set; }
        public virtual int FiscalYear { get; set; }
        public virtual string ImporterCode { get; set; }
        public virtual string ImporterName { get; set; }
        public virtual int? BrandId { get; set; }
        [IgnoreDataMember]
        public virtual string BrandDesc { get; set; }
        public Brand Brand { get; set; }
        public virtual int? ModelId { get; set; }
        [IgnoreDataMember]
        public virtual string ModelDesc { get; set; }
        public Model Model { get; set; }
        public virtual int? ProductionYear { get; set; }
        public virtual int? ColorId { get; set; }
        [IgnoreDataMember]
        public virtual string ColorDesc { get; set; }
        public Colors Color { get; set; }
        public virtual string Chassis { get; set; }
        public virtual string MotorNumber { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual float Value { get; set; }
        public virtual float Taxes { get; set; }
        public virtual int? Cylinders { get; set; }
        public virtual int? OfficeId { get; set; }
        public virtual bool? Discounted { get; set; }
    }
}
