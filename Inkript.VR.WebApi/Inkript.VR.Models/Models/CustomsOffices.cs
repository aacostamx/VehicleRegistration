using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class CustomsOffices {
        public virtual int OfficeId { get; set; }
        public virtual string OfficeNameEn { get; set; }
        public virtual string OfficeNameAr { get; set; }
        public virtual int StatusId { get; set; }
    }
}
