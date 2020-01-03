using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class CarUniqueNumberCustom
    {
        [Required]
        public string ChassisNumber { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public string Trim { get; set; }
    }
}