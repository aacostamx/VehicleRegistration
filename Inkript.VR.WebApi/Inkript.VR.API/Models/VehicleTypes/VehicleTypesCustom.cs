using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class VehicleTypesCustom
    {
        [Required]
        public string VehicleTypeNameEn { get; set; }
        [Required]
        public string VehicleTypeNameAr { get; set; }
    }
}