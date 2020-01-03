using System;
using System.Collections.Generic;

namespace Inkript.VR.API.Models
{
    public class FileInfoInspectionsCustom
    {
        public FileInfoInspectionsCustom()
        {
            ImportInspections = new List<ImportInspectionsCustom>();
        }
        public string BranchName { get; set; }
        public string FileType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? TillDate { get; set; }
        public string Name { get; set; }
        public int? NoRecords { get; set; }
        public DateTime? ImportedDate { get; set; }
        public string ImportStatus { get; set; }
        public IList<ImportInspectionsCustom> ImportInspections { get; set; }
    }
}