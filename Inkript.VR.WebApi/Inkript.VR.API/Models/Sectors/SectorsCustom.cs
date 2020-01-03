using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class SectorsCustom
    {
        [Required]
        public string SectorNameEn { get; set; }
        [Required]
        public string SectorNameAr { get; set; }
    }
}