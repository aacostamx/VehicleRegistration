using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class FileInfoCustoms {
        public FileInfoCustoms() {
			ImportCustoms = new List<ImportCustoms>();
        }
        public virtual int FileInfoCustomId { get; set; }
        public virtual string Name { get; set; }
        public virtual int NoRecords { get; set; }
        public virtual DateTime? ImportedDate { get; set; }
        public virtual string MessageError { get; set; }
        public virtual string ImportStatus { get; set; }
        public virtual IList<ImportCustoms> ImportCustoms { get; set; }
    }
}
