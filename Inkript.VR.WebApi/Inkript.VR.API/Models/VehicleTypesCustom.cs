using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class VehicleTypesCustom {
        public VehicleTypesCustom() { }
        [JsonIgnore]
        public int VehicleTypeId { get; set; }
        [Required]
        public string VehicleTypeNameEn { get; set; }
        [Required]
        public string VehicleTypeNameAr { get; set; }
    }
}
