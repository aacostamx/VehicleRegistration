using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class CarUniqueNumberCustom {
        public CarUniqueNumberCustom() { }
        [Display(Name = "CarUniqueNumber")]
        [JsonIgnore]
        public int CarUniqueNumberVal { get; set; }
        public int? TrimId { get; set; }
        [Required]
        public int ModelId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string Chassis { get; set; }
    }
}
