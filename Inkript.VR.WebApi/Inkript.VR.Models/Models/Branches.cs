namespace Inkript.VR.Models
{

    public class Branches {
        public virtual int BranchId { get; set; }
        public virtual string BranchNameEn { get; set; }
        public virtual string BranchNameAr { get; set; }
        public virtual Status Status { get; set; }
    }
}
