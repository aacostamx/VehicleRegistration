using Inkript.VR.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API.Models
{

    public class FileInfoInspectionsCustom {
        public FileInfoInspectionsCustom()
        {
            ImportInspections = new List<ImportInspectionsCustom>();
        }
        [JsonIgnore]
        public int FileInfoInspectionId { get; set; }
        public string BranchName { get; set; }
        public string FileType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? TillDate { get; set; }
        public string Name { get; set; }
        public int? NoRecords { get; set; }
        public DateTime? ImportedDate { get; set; }
        public string ImportStatus { get; set; }
        public List<ImportInspectionsCustom> ImportInspections { get; set; }
    }
}
