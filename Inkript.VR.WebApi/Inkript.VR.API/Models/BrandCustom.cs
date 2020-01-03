using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models {

    public class BrandCustom {
        public BrandCustom() { }
        [JsonIgnore]
        public int BrandId { get; set; }
        [Required]
        public string BrandNameEN { get; set; }
        [Required]
        public string BrandNameAR { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
