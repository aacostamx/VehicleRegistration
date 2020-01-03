using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class ModelCustom {
        public ModelCustom() { }
        [JsonIgnore]
        public int ModelId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
