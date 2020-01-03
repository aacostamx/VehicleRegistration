using System;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{

    public class Application
    {
        public Application() { }
        public virtual int ApplicationId { get; set; }
        public virtual int BranchId { get; set; }
        public virtual int? SectionId { get; set; }
        public virtual string BusinessProcess { get; set; }
        public virtual string CarPlateInfo { get; set; }
        public virtual int CarUniqueNumber { get; set; }
        public virtual string CarDetails { get; set; }
        public virtual int? OwnerType { get; set; }
        public virtual string OwnersInfo { get; set; }
        public virtual string Fees { get; set; }
        public virtual string Documents { get; set; }
        public virtual string AutomaticallyCalculatedFees { get; set; }
        public virtual string OutputDocuments { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual string ProcessedBy { get; set; }
        public virtual string InvoicesNumbers { get; set; }
        [IgnoreDataMember]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual int? UpdatedBy { get; set; }
    }
}
