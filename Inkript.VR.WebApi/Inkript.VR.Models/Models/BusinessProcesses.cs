using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{

    public class BusinessProcesses
    {
        public BusinessProcesses()
        {
            BPFee = new List<BPFee>();
            BPOutputRel = new List<BPOutputRel>();
            OutputGroup = new List<OutputGroup>();
            BPSectorVehicle = new List<BPSectorVehicle>();
            BPRelationships = new List<BPRelationships>();
            SecondaryBusinessProcesses = new List<SecondaryBusinessProcesses>();
            DocumentProcessRelationship = new List<DocumentProcessRelationship>();
        }

        public virtual int BPId { get; set; }
        public virtual string BPNameEn { get; set; }
        public virtual string BPNameAr { get; set; }
        public virtual string BPType { get; set; }
        public virtual string Icon { get; set; }
        public virtual string HotKey { get; set; }
        public virtual string BPUrl { get; set; }
        public virtual int CarStatusId { get; set; }
        public virtual int StatusId { get; set; }
        //public virtual int SectorId { get; set; }
        //public virtual int VehicleTypeId { get; set; }
        //[IgnoreDataMember]
        //public virtual int CarStatusId { get; set; }
        //public virtual CarStatus CarStatus { get; set; }
        //[IgnoreDataMember]
        //public int StatusId { get; set; }
        //public virtual Status Status { get; set; }

        public virtual IList<BPFee> BPFee { get; set; }
        public virtual IList<BPOutputRel> BPOutputRel { get; set; }
        public virtual IList<OutputGroup> OutputGroup { get; set; }
        public virtual IList<BPSectorVehicle> BPSectorVehicle { get; set; }
        public virtual IList<BPRelationships> BPRelationships { get; set; }
        public virtual IList<DocumentProcessRelationship> DocumentProcessRelationship { get; set; }

        public IList<SecondaryBusinessProcesses> SecondaryBusinessProcesses { get; set; }


    }
}
