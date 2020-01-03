using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class BranchesCustom {
        public BranchesCustom() { }
        [JsonIgnore]
        public int BranchId { get; set; }
        [Required]
        public string BranchNameEn { get; set; }
        [Required]
        public string BranchNameAr { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
