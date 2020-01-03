using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class ServerMessages {
        public virtual int ServerMessagesId { get; set; }
        public virtual string Code { get; set; }
        public virtual string Type { get; set; }
        public virtual string Arabic { get; set; }
        public virtual string English { get; set; }
    }
}
