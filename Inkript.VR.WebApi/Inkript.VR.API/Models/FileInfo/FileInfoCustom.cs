using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class FileInfoCustom
    {
        public FileInfoCustom()
        {
            ImportCustoms = new List<ImportCustomsCustom>();
        }

        [Required]
        public string Name { get; set; }
        public int NoRecords { get; set; }
        public DateTime? ImportedDate { get; set; }
        public string ImportStatus { get; set; }
        [JsonIgnore]
        public string MessageError { get; set; }

        [JsonProperty(PropertyName = "Car")]
        public IList<ImportCustomsCustom> ImportCustoms { get; set; }
    }
}