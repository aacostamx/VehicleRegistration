using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class SectorsCustom {
        public SectorsCustom() { }
        [JsonIgnore]
        public int SectorId { get; set; }
        [Required]
        public string SectorNameEn { get; set; }
        [Required]
        public string SectorNameAr { get; set; }
    }
}
