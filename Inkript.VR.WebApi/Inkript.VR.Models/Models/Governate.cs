using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Governate {
        public virtual int GovernateId { get; set; }
        public virtual string GovernateNameEN { get; set; }
        public virtual string GovernateNameAR { get; set; }
        public virtual IList<Districts> Districts { get; set; }
    }
}
