using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.Models
{

    public class CarUniqueNumber {
        [Display(Name = "CarUniqueNumber")]
        public virtual int CarUniqueNumberVal { get; set; }
        public virtual TRIM TRIM { get; set; }
        public virtual Model Model { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual string Chassis { get; set; }
    }
}
