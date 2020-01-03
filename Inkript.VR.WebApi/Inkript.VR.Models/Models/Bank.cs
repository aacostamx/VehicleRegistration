using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Bank {
        public virtual int BankId { get; set; }
        public virtual string BankName { get; set; }
        public virtual int StatusId { get; set; }
    }
}
