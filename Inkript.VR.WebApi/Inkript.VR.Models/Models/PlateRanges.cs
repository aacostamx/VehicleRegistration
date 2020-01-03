using System;
using System.Collections.Generic;

namespace Inkript.VR.Models
{

    public class PlateRanges
    {
        public PlateRanges()
        {
            PlateNumberPool = new List<PlateNumberPool>();
        }

        public virtual int PlateRangeId { get; set; }
        public virtual string RangeName { get; set; }
        public virtual int StartNumber { get; set; }
        public virtual int EndNumber { get; set; }
        public virtual int? TotalAvailable { get; set; }
        public virtual int? SectorId { get; set; }
        public virtual int? VehicleTypeId { get; set; }
        public virtual int PlateCodeId { get; set; }
        public virtual int? BranchId { get; set; }
        public virtual string SQLSequence { get; set; }
        public virtual int StatusId { get; set; }
        public virtual int? PriorityLevel { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string Prefix { get; set; }
        public virtual string DiplomaticLevel { get; set; }

        public IList<PlateNumberPool> PlateNumberPool { get; set; }
    }
}
