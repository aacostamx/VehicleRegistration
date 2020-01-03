using System.ComponentModel.DataAnnotations;


namespace Inkript.VR.API.Models
{
    public class BrandCustom
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}