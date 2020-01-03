using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class DocumentInput {
        public virtual int DocumentInputId { get; set; }
        public virtual int DocumentId { get; set; }
        public virtual string InputType { get; set; }
        public virtual string InputNameEn { get; set; }
        public virtual string InputNameAr { get; set; }
        public virtual string InputRequired { get; set; }
    }
}
