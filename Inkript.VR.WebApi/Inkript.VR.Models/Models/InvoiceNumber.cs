using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class InvoiceNumber {
        public virtual int InvoiceNumberId { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
