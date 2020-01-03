using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class BranchesCustom
    {
        [Required]
        public string BranchNameEn { get; set; }
        [Required]
        public string BranchNameAr { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}