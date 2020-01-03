using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models {
    
    public class FileInfoCustomsCustom {
        public FileInfoCustomsCustom()
        {
            ImportCustoms = new List<ImportCustomsCustom>();
        }

        public int FileInfoCustomId { get; set; }
        [Required]
        public string Name { get; set; }
        public int NoRecords { get; set; }
        public DateTime? ImportedDate { get; set; }
        [JsonIgnore]
        public string MessageError { get; set; }
        public string ImportStatus { get; set; }

        [JsonProperty(PropertyName = "Car")]
        public IList<ImportCustomsCustom> ImportCustoms { get; set; }
    }
}
