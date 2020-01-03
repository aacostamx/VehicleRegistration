using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class BPFee {
        public virtual int BPFeeId { get; set; }
        public virtual long FeeId { get; set; }
        public virtual int BPId { get; set; }
        public virtual int SectorId { get; set; }
        public virtual int VTId { get; set; }
        public virtual decimal? TaxPercentageApplicable { get; set; }
    }
}
