using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class ApplicationDocuments {
        public virtual int AppDocumentId { get; set; }
        public virtual int? ApplicationId { get; set; }
        public virtual int? DocumentId { get; set; }
    }
}
