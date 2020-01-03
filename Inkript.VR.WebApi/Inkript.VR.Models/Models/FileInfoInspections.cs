using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class FileInfoInspections {
        public FileInfoInspections()
        {
            ImportInspections = new List<ImportInspections>();
        }
        public virtual int FileInfoInspectionId { get; set; }
        public virtual string BranchName { get; set; }
        public virtual string FileType { get; set; }
        public virtual DateTime? FromDate { get; set; }
        public virtual DateTime? TillDate { get; set; }
        public virtual string Name { get; set; }
        public virtual int? NoRecords { get; set; }
        public virtual DateTime? ImportedDate { get; set; }
        public virtual string ImportStatus { get; set; }
        public virtual IList<ImportInspections> ImportInspections { get; set; }
    }
}
